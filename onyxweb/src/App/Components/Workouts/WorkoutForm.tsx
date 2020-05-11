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
                    <Formik key={uuid()} onSubmit={handleFormSubmit}  enableReinitialize={true} initialValues={{exercises: exercisesForForm}}
                        render={({values, handleChange, handleSubmit}) => (
                            <Form onSubmit={handleSubmit}>
                                <FieldArray 
                                    name="exercises"
                                    render={arrayHelpers => ( 
                                        values.exercises.map((e, index) => (
                                            <Fragment key={index}>
                                                <Header>{e.name}</Header>
                                                <Form.Row>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Sets</Form.Label>
                                                        <Form.Control key={`${index}_sets`} type='number' name={`exercises[${index}].sets`} value={(e.sets)} onChange={handleChange} />
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
                    
            
            
                // {/* <Formik onSubmit={handleFormSubmit} initialValues={exercise}>
                //     {({
                //         handleSubmit,
                //         handleChange,
                //         values
                //     }) => (
                //     <Form onSubmit={handleSubmit} >
                //         <Form.Row>
                //             <Form.Group as={Col} controlId='01'>
                //                 <Form.Label>Sets</Form.Label>
                //                 <Form.Control 
                //                     type='number'
                //                     name='sets'
                //                     value={values.sets}
                //                     onChange={handleChange}
                //                 />
                //             </Form.Group>
                //             <Form.Group as={Col} controlId='02'>
                //                 <Form.Label>Sets</Form.Label>
                //                 <Form.Control 
                //                     type='number'
                //                     name='reps'
                //                     value={values.reps}
                //                     onChange={handleChange}
                //                 />
                //             </Form.Group>
                //         </Form.Row>
                //         <Form.Row>
                //         <Form.Group as={Col} controlId='03'>
                //                 <Form.Label>Sets</Form.Label>
                //                 <Form.Control 
                //                     as='textarea'
                //                     name='description' 
                //                     rows={10}
                //                     value={values.description}
                //                     onChange={handleChange}
                //                 />
                //             </Form.Group>
                //         </Form.Row>
                //         <Form.Row>
                //             <Form.Group as={Col} controlId='04'>
                //                 <Button content="Submit" floated='right' type="submit"/>
                //             </Form.Group>
                            
                //         </Form.Row>
                //     </Form>
                // )}
                // </Formik> */}
 
    )
}

export default observer(WorkoutForm)
