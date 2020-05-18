import axios, { AxiosResponse } from 'axios'
import { IUser, IUserFormValues } from '../Models/User';
import { toast } from 'react-toastify';
import { history } from '../..';
import { Message } from '../Models/Message';
import { Membership } from '../Models/Memberships/Membership';
import { Exercise, Workout } from '../Models/Workout';
import { IDetailedMembership } from '../Models/Memberships/IDetailedMembership';

axios.defaults.baseURL = "http://localhost:5000/api"

//#region interceptors
axios.interceptors.request.use((config) => {
    const token = window.localStorage.getItem('jwt');

    if(token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    
    return config;
}, error => {
    console.log("Error with the request interceptor", error);
    return Promise.reject(error);
});

axios.interceptors.response.use(undefined, error => {
    if(error.message === "Network Error" && !error.response) {
        toast.error("Network Error - Server Down");
    }

    const {status, data, config} = error.response;
    
    if(status === 404) {
        history.push("/notfound");
    }

    if(status === 400 && config.method === 'get' && data.errors.hasOwnProperty('id')) {
        history.push("/notfound");
    }
    if(status === 500) {
        toast.error("Server Error - Check terminal for more info!");
    }
    
    throw error.response;
}) 
//#endregion

const responseBody = (response: AxiosResponse ) => response.data;

const requests = {
    get : (url: string) => axios.get(url).then(responseBody),
    post : (url: string, body: {}) => axios.post(url, body).then(responseBody),
    put : (url: string, body: {}) => axios.put(url, body).then(responseBody),
    delete: (url: string) => axios.delete(url).then(responseBody)
};

const User = {
    current: () : Promise<IUser> => requests.get('/user'),
    login: (user: IUserFormValues) : Promise<IUser> => requests.post(`/user/login`, user),
    register: (user: IUserFormValues) : Promise<IUser> => requests.post(`/user/register`, user)
}

const Messages = {
    list: () : Promise<Message[]> => requests.get("/message/messages")
}

const Memberships = {
    list : () : Promise<Membership[]> => requests.get("/membership/memberships"),
    detailed : (membershipId: string) => requests.get(`/membership/memberships/${membershipId}`),
    update: (membership: IDetailedMembership) => requests.put("/membership/memberships/update", membership),
    create: (membership: IDetailedMembership) => requests.post("/membership/memberships/create", membership)
}

const Workouts = {
    editExercise: (exercise: Exercise) => requests.post("/workout/create", exercise),
    createExercise: (exercise: Exercise) => requests.put("/workout/update", exercise),
    listWorkouts: (): Promise<Workout[]> => requests.get(`/workout/workouts`),
    listExercises: (workoutId: string, dateRecorded: string) : Promise<Exercise[]> => requests.get(`/workout/exercises/${workoutId}/${dateRecorded}`)
}

export default {
    User,
    Messages,
    Memberships,
    Workouts
}