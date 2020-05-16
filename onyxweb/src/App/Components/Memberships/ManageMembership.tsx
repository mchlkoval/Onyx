import React, { useEffect, Fragment, useContext, useState } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import {Formik, FieldArray} from 'formik';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedMembership } from '../../Models/Memberships/IDetailedMembership';
import { LoadingComponent } from '../General/Loading/LoadingComponent';

interface IProps {
    id: string
}

const ManageMembership : React.FC<RouteComponentProps<IProps>>= ({match, history}) => {

    const root = useContext(RootStoreContext);    
    const {loadVerboseMembership} = root.membershipStore;

    const [detail, setDetail] = useState(new DetailedMembership());
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if(match.params.id) {
            setLoading(true);
            console.log("Calling use effect");
            loadVerboseMembership(match.params.id).then((data) => 
                setDetail(new DetailedMembership(data))             
            ).finally(() => {
                setLoading(false)});
        }
    }, [loadVerboseMembership, match.params.id])

    const handleFormSubmit = (values: any) => {
        console.log(JSON.stringify(values, null, 2));
    }

    const addNewWorkout = (e: DetailedMembership) => {
        e.workouts.push({
            name: "",
            description: "",
            dateOfWorkout: new Date(),
            minSets: 0,
            minReps: 0,
            minWeight: 0,
            exercises: [{
                description: "",
                name: "",
            }]
        })

        detail.workouts = e.workouts;
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
                                            <Form.Label>Description</Form.Label>
                                            <Form.Control type='text' name="description" value={values.description} onChange={handleChange} />
                                        </Form.Group>
                                    </Form.Row>
                                    <Segment clearing>
                                        <Header floated='left'>Workouts</Header>
                                        <Button floated='right' type='button' positive onClick={(e) => addNewWorkout(values)}>Add Workout</Button>
                                    </Segment>
                                    <FieldArray name="workouts" render={arrayHelpers => (
                                        values.workouts.map((work, outerIndex) => (
                                            <Segment key={outerIndex} clearing>
                                           <Form.Row>
                                               <Form.Group as={Col}>
                                                    <Form.Label>Name</Form.Label>
                                                    <Form.Control key={`${outerIndex}_name`} type='text' name={`workouts[${outerIndex}].name`} value={values.workouts[outerIndex].name} onChange={handleChange}/>
                                               </Form.Group>
                                               <Form.Group as={Col}>
                                                    <Form.Label>Date Of Workout</Form.Label>
                                                    <Form.Control key={`${outerIndex}_date`} type='date' name={`workouts[${outerIndex}].dateOfWorkout`} value={new Date(values.workouts[outerIndex].dateOfWorkout).toISOString().split('T')[0]} onChange={handleChange}/>
                                               </Form.Group>    
                                           </Form.Row>
                                           <Form.Row>
                                                <Form.Group as={Col}>
                                                    <Form.Label>Min. Sets</Form.Label>
                                                    <Form.Control type='number' name={`workouts[${outerIndex}].minSets`} value={values.workouts[outerIndex].minSets} onChange={handleChange} />
                                                </Form.Group>
                                                <Form.Group as={Col}>
                                                    <Form.Label>Min. Reps</Form.Label>
                                                    <Form.Control type='number' name={`workouts[${outerIndex}].minReps`} value={values.workouts[outerIndex].minReps} onChange={handleChange} />
                                                </Form.Group>
                                                <Form.Group as={Col}>
                                                    <Form.Label>Min. Weight</Form.Label>
                                                    <Form.Control type='number' name={`workouts[${outerIndex}].minWeight`} value={values.workouts[outerIndex].minWeight ?? 0} onChange={handleChange} />
                                                </Form.Group>
                                           </Form.Row>
                                           <Form.Row>
                                                <Form.Group as={Col}>
                                                    <Form.Label>Description</Form.Label>
                                                    <Form.Control key={`${outerIndex}_name`} type='text' name={`workouts[${outerIndex}].description`} value={values.workouts[outerIndex].description} onChange={handleChange}/>
                                               </Form.Group>
                                           </Form.Row>

                                           <Button floated='right' negative onClick={() => arrayHelpers.remove(outerIndex)}>Remove Workout</Button>
                                       </Segment>
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
