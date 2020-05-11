import React, { Fragment, useContext, useState, useEffect } from 'react'
import { Header, Container, Segment, Button } from 'semantic-ui-react'
import { RootStoreContext } from '../../Stores/RootStore';
import { ExerciseFormValues } from '../../Models/Classes/ExerciseFormValues';
import {Formik, FieldArray, Field} from 'formik';
import {v4 as uuid} from 'uuid'
import { RouteComponentProps } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import Form from 'react-bootstrap/Form'
import Jumbotron from 'react-bootstrap/Jumbotron'
import Col from 'react-bootstrap/Col';
import { Exercise } from '../../Models/Workout';


interface IProps {
    workoutId: string
}

const WorkoutForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {
    
    const rootStore = useContext(RootStoreContext);
    const {getExercises, exercises, exercisesForForm} = rootStore.workoutStore;

    useEffect(() => {
        
        if(match.params.workoutId) {
            getExercises(match.params.workoutId);
        }
    }, [getExercises, match.params.workoutId])

    const handleFormSubmit = (values: any) => {
        alert(JSON.stringify(values, null, 2));
        // if(!values.id) {
        //     let newExercise = {
        //         ...values,
        //         id: uuid()
        //     };
        //     createExercise(newExercise);
        // } else {
        //     editExercise(values);
        // }
    }

    return (
        <Fragment>
            
            <Container>
                <Segment>
                    <Header>Record Workout</Header>
                    <Formik key={uuid()} onSubmit={handleFormSubmit}  enableReinitialize={true} initialValues={exercisesForForm}
                        render={({values, handleChange, handleSubmit}) => (
                            <Form onSubmit={handleSubmit}>
                                <FieldArray 
                                    name="exercises"
                                    render={arrayHelpers => ( 
                                        values.map((e, index) => (
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
                                    
                                    )
                                )}/>
                                <Form.Row>
                                    <Form.Group as={Col} controlId='04'>
                                        <Button content="Submit" floated='right' type="submit"/>
                                    </Form.Group>
                                </Form.Row>
                            </Form>
                        )}
                    />  

                </Segment>
            </Container>
        </Fragment>
                    
                //     {/* {exercises.map((exercise, index) => 
                //         (
                //             <Fragment key={exercise.id}>
                //                 <Header>{exercise.name}</Header>
                //                     <Form.Row>
                //                         <Form.Group as={Col}>
                //                             <Form.Label key={"1" + values[index].id} htmlFor={"i" + values[index].id}>Sets</Form.Label>
                //                             <Form.Control key={"i" + values[index].id} data-idx={index} type="number" name={`${index}_sets`} value={values[index].sets} onChange={handleChange}/>
                //                         </Form.Group>
                //                     </Form.Row>
                                    
                //                     <Form.Row>
                //                         <Form.Group as={Col}>
                //                             <Form.Label key={"2" + values[index].id} htmlFor={"o" + values[index].id}>Reps</Form.Label>
                //                             <Form.Control key={"o" + values[index].id} data-idx={index} type="number" name={`${index}_reps`} value={values[index].reps} onChange={handleChange}/>
                //                         </Form.Group>
                //                     </Form.Row> 
                //                     <Form.Row>
                //                         <Form.Group as={Col}>
                //                             <Form.Label key={"3" + values[index].id} htmlFor={"p" + values[index].id}>Weight</Form.Label>
                //                             <Form.Control key={"p" + values[index].id} data-idx={index} type="number" name={`${index}_weight`} value={values[index].weight} onChange={handleChange}/>
                //                         </Form.Group>
                //                     </Form.Row>       
                //             </Fragment>                              
                //         )
                //         )} */}
                //         {/* <Form.Row>
                //             <Form.Group as={Col} controlId='04'>
                //                 <Button content="Submit" floated='right' type="submit"/>
                //             </Form.Group>
                //         </Form.Row>     
                //         </Form> */}
                    
    )
}

export default observer(WorkoutForm)
