import axios, { AxiosResponse } from 'axios'
import { IUser, IUserFormValues } from '../Models/User';

axios.defaults.baseURL = "http://localhost:5000/api"

//#region interceptors
axios.interceptors.request.use((config) => {
    const token = window.localStorage.getItem('jwt');

    if(token) {
        config.headers.Authorization = `Bearer ${token}`;
    }
    
    return config;
}, error => {
    return Promise.reject(error);
});

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

export default {
    User
}