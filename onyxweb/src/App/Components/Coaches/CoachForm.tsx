import React, { useContext, useState, useEffect, Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedCoach, IAssignedAthletes } from '../../Models/Coaches/IDetailedCoach';
import { LoadingComponent } from '../General/Loading/LoadingComponent';
import { Container, Segment, Header, Divider, Button, Icon } from 'semantic-ui-react';
import { Formik, FieldArray } from 'formik';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table'
import { GenderType } from '../../Models/Enums/Gender';
import { handleGender, handleDate } from '../../Utility/UtilityFunctions';
import AvailableAthletesModal from './Modals/AvailableAthletesModal';

interface IProps {
    id: string
}

const CoachForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {
    
    const root = useContext(RootStoreContext);
    const {loadCoach, createCoach, editCoach} = root.coachStore;
    const {openModal} = root.modalStore;

    const [coach, setCoach] = useState(new DetailedCoach());
    const [loading, setLoading] = useState(false);


    useEffect(() => {
        
        if(match.params.id !== undefined) {
            setLoading(true);
            loadCoach(match.params.id).then((data) => {
                setCoach(new DetailedCoach(data));
            }).finally(() => {
                setLoading(false);
            })
        }
    }, [loadCoach, match.params])

    const addNewlySelectedAthlete = (athlete : IAssignedAthletes) => {
        coach.assignedAthletes?.push(athlete);
        setCoach(new DetailedCoach(coach));
    }

    const handleFormSubmit = (values: any) => {
        values.gender = parseInt(values.gender);
        if(values.id !== "") {
            editCoach(values);
        } else {
            createCoach(values);
        }
    }

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Coach</Header>
                <Formik onSubmit={(values) => handleFormSubmit(values)} initialValues={coach}
                render = {
                    ({values, handleChange, handleSubmit}) => (
                        <Form onSubmit={handleSubmit}>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Name</Form.Label>
                                    <Form.Control type='text' name="name" value={values.name} onChange={handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Gender</Form.Label>
                                    <Form.Control as="select" name="gender" value={values.gender} onChange={handleChange}>
                                                        <option value={GenderType.Male} >Male</option>
                                                        <option value={GenderType.Female}>Female</option>
                                                        <option value={GenderType.Other} >Other</option>
                                                    </Form.Control>
                                </Form.Group>
                                <Form.Group>
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control type="email" name="email" value={values.email} onChange={handleChange}/>
                                </Form.Group>
                            </Form.Row>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Date Hired</Form.Label>
                                    <Form.Control type='date' name="dateHired" value={handleDate(values.dateHired)} onChange={handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Date of Birth</Form.Label>
                                    <Form.Control type='date' name="dateOfBirth" value={handleDate(values.dateOfBirth)} onChange={handleChange}/>
                                </Form.Group>
                            </Form.Row>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Country</Form.Label>
                                    <Form.Control type='text' name="country" value={values.country} onChange={handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>State</Form.Label>
                                    <Form.Control type='text' name="state" value={values.state} onChange={handleChange}/>
                                </Form.Group>  
                                <Form.Group as={Col}>
                                    <Form.Label>City</Form.Label>
                                    <Form.Control type='text' name="city" value={values.city} onChange={handleChange}/>
                                </Form.Group>    
                            </Form.Row>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Address 1</Form.Label>
                                    <Form.Control type='text' name="address" value={values.address} onChange={handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Address 2</Form.Label>
                                    <Form.Control type='text' name="address2" value={values.address2} onChange={handleChange}/>
                                </Form.Group>      
                            </Form.Row>
                            <Divider />
                            <Segment clearing>
                                <Header floated="left">Assigned Athletes</Header>
                                <Button positive content="New Athlete" floated="right" type="button" onClick={() => openModal(<AvailableAthletesModal coachId={match.params.id} handleSelectAthlete={addNewlySelectedAthlete}/>)}/>
                                
                                {values.assignedAthletes !== null ? 
                                    <Table striped bordered hover>
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Date Joined</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <FieldArray name="assignedAthletes" render={arrayHelpers => (
                                        values.assignedAthletes!.map((athlete, index) => (
                                            <tr key={athlete.athleteId}>
                                                <td>{athlete.name}</td>
                                                <td>
                                                    {handleGender(athlete.gender)}
                                                </td>
                                                <td>
                                                    {handleDate(athlete.dateJoined)}
                                                </td>
                                                <td>
                                                    <Button floated="right" type="button" onClick={() => arrayHelpers.remove(index)}>
                                                        <Icon name="user times"/>
                                                    </Button>
                                                    <Button floated="right" type="button">
                                                        <Icon name="envelope"/>
                                                    </Button>
                                                </td>
                                            </tr>
                                            ))
                                        )}/>
                                    </tbody>
                                </Table>
                                : null}
                                
                            </Segment>
                        
                            <Divider />
                            <Form.Row>
                                <Form.Group as={Col} controlId='04'>
                                    <Button content="Save" floated='right' type="submit" positive/>
                                </Form.Group>
                            </Form.Row>
                            
                        </Form>
                    )
                }/>
            </Segment>
        </Container>
    )
}

export default observer(CoachForm)
