import React, { useContext, useEffect, useState } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore'
import { DetailedAthlete, IAssignedCoach } from '../../Models/Athlete/IDetailedAthlete'
import { LoadingComponent } from '../General/Loading/LoadingComponent'
import { Container, Segment, Header, Button, Icon } from 'semantic-ui-react'
import { Formik, FieldArray } from 'formik'
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table'
import { GenderType } from '../../Models/Enums/Gender'
import { handleGender } from '../../Utility/UtilityFunctions'
import AvailableAthletesModal from '../Coaches/Modals/AvailableAthletesModal'
import AvailableCoachesModal from './Modals/AvailableCoachesModal'

interface IProps {
    id: string
}

const AthleteForm : React.FC<RouteComponentProps<IProps>>= ({match, history}) => {


    const root = useContext(RootStoreContext);
    const { loadAthlete, editAthlete, createAthlete} = root.athleteStore;
    const { openModal } = root.modalStore;

    const [athlete, setAthlete] = useState(new DetailedAthlete());
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        setLoading(true);
        if(match.params.id !== undefined) {
            loadAthlete(match.params.id).then((data) => {
                setAthlete(new DetailedAthlete(data));
            }).finally(() => {
                setLoading(false);
            });
        }

    }, [loadAthlete, match.params])

    const addNewlySelectedCoach = (coach : IAssignedCoach) => {
        athlete.assignedCoaches?.push(coach);
        setAthlete(new DetailedAthlete(athlete));
    }

    const handleFormSubmit = (values: any) => {
        values.gender = parseInt(values.gender);
        if(values.id !== "") {
            editAthlete(values);
        } else {
            createAthlete(values);
        }
    }

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Athlete</Header>
                <Formik onSubmit={(values) => handleFormSubmit(values)} initialValues={athlete} 
                    render={
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
                                    <Form.Group as={Col}>
                                        <Form.Label>Date Of Birth</Form.Label>
                                        <Form.Control type='date' name="dateOfBirth" value={new Date(values.dateOfBirth).toISOString().split('T')[0]} onChange={handleChange}/>
                                    </Form.Group>
                                    <Form.Group as={Col}>
                                        <Form.Label>Weight</Form.Label>
                                        <Form.Control type='number' name="weight" value={values.weight} onChange={handleChange}/>
                                    </Form.Group>
                                </Form.Row>
                                <Form.Row>
                                    <Form.Group as={Col}>
                                        <Form.Label>City</Form.Label>
                                        <Form.Control type="text" name="city" value={values.city} onChange={handleChange} />
                                    </Form.Group>
                                    <Form.Group as={Col}>
                                        <Form.Label>State</Form.Label>
                                        <Form.Control type="text" name="state" value={values.state} onChange={handleChange} />
                                    </Form.Group>
                                    <Form.Group as={Col}>
                                        <Form.Label>Country</Form.Label>
                                        <Form.Control type="text" name="country" value={values.country} onChange={handleChange} />
                                    </Form.Group>
                                </Form.Row>
                                <Form.Row>
                                    <Form.Group as={Col}>
                                        <Form.Label>Address</Form.Label>
                                        <Form.Control type="text" name="address" value={values.address} onChange={handleChange} />
                                    </Form.Group>
                                    <Form.Group as={Col}>
                                        <Form.Label>Address 2</Form.Label>
                                        <Form.Control type="text" name="address2" value={values.address2} onChange={handleChange} />
                                    </Form.Group>
                                </Form.Row>
                                <Segment clearing>
                                    <Header floated="left">Assigned Coaches</Header>
                                    <Button positive type="button" content="Assign New Coach" floated="right" onClick={() => openModal(<AvailableCoachesModal athleteId={match.params.id} handleSelectCoach={addNewlySelectedCoach}/>)}/>
                                    {values.assignedCoaches !== null ? 
                                        <Table striped bordered hover>
                                            <thead>
                                                <tr>
                                                    <th>Name</th>
                                                    <th>Gender</th>
                                                    <th>Actions</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <FieldArray name="assignedCoaches" render={arrayHelpers => (
                                                    values.assignedCoaches?.map((coach, index) => (
                                                        <tr key={coach.id}>
                                                            <td>{coach.name}</td>
                                                            <td>{handleGender(coach.gender)}</td>
                                                            <td><Button floated="right" type="button" onClick={() => arrayHelpers.remove(index)}>
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
                                        : null
                                    }
                                </Segment>
                                <Form.Row>
                                    <Form.Group as={Col}>
                                        <Button floated="right" type="submit" positive content="Save"/>
                                    </Form.Group>
                                </Form.Row>
                            </Form>
                        )
                    }
                />
            </Segment>
        </Container>
    )
}

export default observer(AthleteForm)
