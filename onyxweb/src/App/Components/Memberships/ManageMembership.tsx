import React, { useEffect, Fragment, useContext, useState } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { Container, Segment, Header, Button, Divider } from 'semantic-ui-react'
import {Formik, FieldArray, FieldArrayRenderProps} from 'formik';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedMembership } from '../../Models/Memberships/IDetailedMembership';
import { LoadingComponent } from '../General/Loading/LoadingComponent';
import {v4 as uuid} from 'uuid';

interface IProps {
    id: string
}

const ManageMembership : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {

    const root = useContext(RootStoreContext);    
    const {loadVerboseMembership, editMembership, createMembership} = root.membershipStore;

    const [detail, setDetail] = useState(new DetailedMembership());
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if(match.params.id !== "create") {
            setLoading(true);
            loadVerboseMembership(match.params.id).then((data) => 
                setDetail(new DetailedMembership(data))             
            ).finally(() => {
                setLoading(false)});
        }
    }, [loadVerboseMembership, match.params.id])

    const handleFormSubmit = (values: any) => {
        console.log(JSON.stringify(values, null, 2));
        if(values.id !== "") {
            editMembership(values);
        } else {
            createMembership(values);
        }
    }

    const addNewWorkout = (e: FieldArrayRenderProps) => {
        e.push({
            id: "",
            name: "",
            description: "",
            dateOfWorkout: new Date(),
            minSets: 0,
            minReps: 0,
            minWeight: 0,
            exercises: [{
                id: "",
                description: "",
                name: "",
            }]
        })
    }

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Fragment>
            <Container>
                <Segment clearing>
                    <Header>Create Membership</Header>
                    <Formik onSubmit={(values, helpers) => handleFormSubmit(values)} initialValues={detail} enableReinitialize={true}
                    render= {
                        ({ values, handleChange, handleSubmit}) => (
                            <Form onSubmit={handleSubmit}>
                                <Fragment>
                                    <Form.Row>
                                        <Form.Group as={Col}>
                                            <Form.Label>Name</Form.Label>
                                            <Form.Control type='text' name="name" value={values.name} onChange={handleChange}/>
                                        </Form.Group>
                                        <Form.Group as={Col}>
                                            <Form.Label>Price</Form.Label>
                                            <Form.Control type='number' name="cost" value={values.cost} onChange={handleChange} />
                                        </Form.Group>
                                    </Form.Row>
                                    <Form.Row>
                                               <Form.Group as={Col}>
                                                    <Form.Label>Name</Form.Label>
                                                    <Form.Control type='date' name="startDate" value={new Date(values.startDate).toISOString().split('T')[0]} onChange={handleChange}/>
                                               </Form.Group>
                                               <Form.Group as={Col}>
                                                    <Form.Label>Date Of Workout</Form.Label>
                                                    <Form.Control  type='date' name="endDate" value={new Date(values.endDate).toISOString().split('T')[0]} onChange={handleChange}/>
                                               </Form.Group>    
                                           </Form.Row>
                                    <Form.Row>
                                        <Form.Group as={Col}>
                                            <Form.Label>Description</Form.Label>
                                            <Form.Control type='text' name="description" value={values.description} onChange={handleChange} />
                                        </Form.Group>
                                    </Form.Row>
                                    <Segment clearing>
                                        <Header floated='left'>Workouts</Header>
                                    </Segment>
                                    <FieldArray name="workouts" render={arrayHelpers => (
                                        values.workouts.map((work, outerIndex) => (
                                        <Fragment  key={outerIndex}>   
                                            <Segment clearing>
                                            <Form.Row>
                                                <Form.Group as={Col}>
                                                        <Form.Label>Name</Form.Label>
                                                        <Form.Control key={`${outerIndex}_name`} type='text' name={`workouts[${outerIndex}].name`} value={work.name} onChange={handleChange}/>
                                                </Form.Group>
                                                <Form.Group as={Col}>
                                                        <Form.Label>Date Of Workout</Form.Label>
                                                        <Form.Control key={`${outerIndex}_date`} type='date' name={`workouts[${outerIndex}].dateOfWorkout`} value={new Date(work.dateOfWorkout).toISOString().split('T')[0]} onChange={handleChange}/>
                                                </Form.Group>    
                                            </Form.Row>
                                            <Form.Row>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Min. Sets</Form.Label>
                                                        <Form.Control type='number' name={`workouts[${outerIndex}].minSets`} value={work.minSets} onChange={handleChange} />
                                                    </Form.Group>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Min. Reps</Form.Label>
                                                        <Form.Control type='number' name={`workouts[${outerIndex}].minReps`} value={work.minReps} onChange={handleChange} />
                                                    </Form.Group>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Min. Weight</Form.Label>
                                                        <Form.Control type='number' name={`workouts[${outerIndex}].minWeight`} value={work.minWeight ?? 0} onChange={handleChange} />
                                                    </Form.Group>
                                            </Form.Row>
                                            <Form.Row>
                                                    <Form.Group as={Col}>
                                                        <Form.Label>Description</Form.Label>
                                                        <Form.Control key={`${outerIndex}_name`} type='text' name={`workouts[${outerIndex}].description`} value={work.description} onChange={handleChange}/>
                                                </Form.Group>
                                            </Form.Row>

                                                <Segment clearing>
                                                    <FieldArray name={`workouts.${outerIndex}.exercises`} render={innerHelpers => (
                                                        values.workouts[outerIndex].exercises.map((exercise, innerIndex) => (
                                                            <Fragment key={innerIndex}>
                                                                <Form.Row>
                                                                    <Form.Group as={Col}>
                                                                        <Form.Label>Name</Form.Label>
                                                                        <Form.Control key={`${innerIndex}_name`} type='text' name={`workouts[${outerIndex}].exercises[${innerIndex}].name`} value={exercise.name} onChange={handleChange} />
                                                                    </Form.Group>
                                                                </Form.Row>
                                                                <Form.Row>
                                                                    <Form.Group as={Col}>
                                                                        <Form.Label>Description</Form.Label>
                                                                        <Form.Control key={`${innerIndex}_description`} type='text' name={`workouts[${outerIndex}].exercises[${innerIndex}].description`} value={exercise.description} onChange={handleChange} />
                                                                    </Form.Group>
                                                                </Form.Row>
                                                                <Segment clearing>
                                                                {innerIndex === values.workouts[outerIndex].exercises.length-1 ? <Button floated='right' type='button' positive onClick={() => innerHelpers.push({description: "", name: "",})}>Add Exercise</Button> : null}
                                                                <Button floated='right' type='button' negative onClick={() => innerHelpers.remove(innerIndex)}>Remove Exercise</Button>
                                                                </Segment>
                                                            </Fragment>
                                                            
                                                        ))
                                                    )}/>
                                                    
                                                </Segment>
                                                        {values.workouts && values.workouts.length > 0 ? (
                                                            <Fragment>
                                                                {outerIndex === values.workouts.length-1 ? <Button floated='right' type='button' positive onClick={() => addNewWorkout(arrayHelpers)}>Add Workout</Button> : null}
                                                                <Button floated='right' negative onClick={() => {arrayHelpers.remove(outerIndex); }}>Remove Workout</Button>
                                                            </Fragment>
                                                        ) : 
                                                            <Button type='button' positive onClick={() => addNewWorkout(arrayHelpers)}>Add Workout</Button> 
                                                        }
                                            </Segment>
                                            <Divider section key={uuid()}/>
                                        </Fragment>
                                        ))
                                        )}/>
                                </Fragment>                               
                                <Form.Row>
                                    <Form.Group as={Col} controlId='04'>
                                        <Button content="Create" floated='right' type="submit" positive/>
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

export default observer(ManageMembership)
