import React, { Fragment, useContext, useEffect } from 'react'
import { Header, Container, Segment, Button } from 'semantic-ui-react'
import { RootStoreContext } from '../../Stores/RootStore';
import {Formik} from 'formik';
import {v4 as uuid} from 'uuid'
import { RouteComponentProps } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';


interface IProps {
    workoutId: string,
    dateRecorded: string
}

const WorkoutForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {
    
    const rootStore = useContext(RootStoreContext);
    const {getExercises, exercisesForForm} = rootStore.workoutStore;

    useEffect(() => {
        
        if(match.params.workoutId) {
            let date = new Date(match.params.dateRecorded).toISOString();
            console.log("Date: ", date);
            console.log("workoutid: ", match.params.workoutId);
            getExercises(match.params.workoutId, date);
        }
    }, [getExercises, match.params.workoutId, match.params.dateRecorded])

    const handleFormSubmit = (values: any) => {
        alert(JSON.stringify(values, null, 2));
    }

    return (
        <Fragment>  
            <Container>
                <Segment>
                    <Header>Record Workout</Header>
                    <Formik key={uuid()} onSubmit={handleFormSubmit}  enableReinitialize={true} initialValues={exercisesForForm}
                        render=
                        {
                            ({values, handleChange, handleSubmit}) => (
                            <Form onSubmit={handleSubmit}>
                                    {values.map
                                    ((e, index) => 
                                        (
                                            <Fragment key={index}>
                                                <Header>{e.name}</Header>
                                                <Form.Row>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Sets</Form.Label>
                                                        <Form.Control key={`${index}_sets`} type='number' name={`[${index}].sets`} value={(e.sets)} onChange={handleChange} />
                                                    </Form.Group>
                                                </Form.Row>
                                                <Form.Row>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Reps</Form.Label>
                                                        <Form.Control key={`${index}_reps`} type='number' name={`[${index}].reps`} value={(e.reps)} onChange={handleChange} />
                                                    </Form.Group>
                                                </Form.Row>
                                                <Form.Row>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Weight</Form.Label>
                                                        <Form.Control key={`${index}_weight`} type='number' name={`[${index}].weight`} value={(e.weight)} onChange={handleChange} />
                                                    </Form.Group>
                                                </Form.Row>
                                            </Fragment>
                                        )
                                    )}
                                <Form.Row>
                                    <Form.Group as={Col} controlId='04'>
                                        <Button content="Submit" floated='right' type="submit"/>
                                    </Form.Group>
                                </Form.Row>
                            </Form>
                            )
                        }/>  
                </Segment>
            </Container>
        </Fragment>
    )
}

export default observer(WorkoutForm)
