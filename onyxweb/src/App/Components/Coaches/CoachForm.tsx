import React, { useContext, useState, useEffect, Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedCoach } from '../../Models/Coaches/IDetailedCoach';
import { LoadingComponent } from '../General/Loading/LoadingComponent';
import { Container, Segment, Header, Divider, Button, Icon } from 'semantic-ui-react';
import { Formik, FieldArray } from 'formik';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table'
import { GenderType } from '../../Models/Enums/Gender';

interface IProps {
    id: string
}

const CoachForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {
    
    const root = useContext(RootStoreContext);
    const {loadCoach} = root.coachStore;

    const [coach, setCoach] = useState(new DetailedCoach());
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        setLoading(true);
        if(match.params.id !== undefined) {
            loadCoach(match.params.id).then((data) => {
                setCoach(new DetailedCoach(data));
            }).finally(() => {
                setLoading(false);
            })
        }
    }, [loadCoach, match.params])


    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Coach</Header>
                <Formik onSubmit={(values) => console.log(values)} initialValues={coach}
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
                                    <Form.Control type='text' name="gender" value={values.gender} onChange={handleChange}/>
                                </Form.Group>
                            </Form.Row>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Date Hired</Form.Label>
                                    <Form.Control type='date' name="dateHired" value={new Date(values.dateHired).toISOString().split('T')[0]} onChange={handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Date of Birth</Form.Label>
                                    <Form.Control type='date' name="dateOfBirth" value={new Date(values.dateOfBirth).toISOString().split('T')[0]} onChange={handleChange}/>
                                </Form.Group>
                            </Form.Row>
                            <Divider />
                            <Segment clearing>
                                <Header floated="left">Assigned Athletes</Header>
                                <Button positive content="New Athlete" floated="right" type="button" />
                                
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
                                        values.assignedAthletes.map((athlete, index) => (
                                            <tr key={athlete.athleteId}>
                                                <td><Form.Control name={`assignedAthletes[${index}].name`} value={athlete.name} onChange={handleChange}/></td>
                                                <td>
                                                    <Form.Control as="select" name={`assignedAthletes[${index}].gender`} value={athlete.gender} onChange={handleChange}>
                                                        <option value={GenderType.Male} >Male</option>
                                                        <option value={GenderType.Female}>Female</option>
                                                        <option value={GenderType.Other} >Other</option>
                                                    </Form.Control>
                                                </td>
                                                <td>
                                                    <Form.Control type="date" name={`assignedAthletes[${index}.dateJoined]`} value={new Date(athlete.dateJoined).toISOString().split('T')[0]} onChange={handleChange}/>
                                                </td>
                                                <td>
                                                    <Button floated="right" type="button">
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
