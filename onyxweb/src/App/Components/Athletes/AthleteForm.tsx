import React, { useContext, useEffect, useState } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore'
import { DetailedAthlete } from '../../Models/Athlete/IDetailedAthlete'
import { LoadingComponent } from '../General/Loading/LoadingComponent'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import { Formik } from 'formik'
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import { GenderType } from '../../Models/Enums/Gender'

interface IProps {
    id: string
}

const AthleteForm : React.FC<RouteComponentProps<IProps>>= ({match, history}) => {


    const root = useContext(RootStoreContext);
    const { loadAthlete} = root.athleteStore;

    const [athlete, setAthlete] = useState(new DetailedAthlete());
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        console.log("Params: ", match.params);
        setLoading(true);
        if(match.params.id !== undefined) {
            loadAthlete(match.params.id).then((data) => {
                setAthlete(new DetailedAthlete(data));
            }).finally(() => {
                setLoading(false);
            });
        }

    }, [loadAthlete, match.params])

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Athlete</Header>
                <Formik onSubmit={(values) => console.log(values)} initialValues={athlete} 
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
