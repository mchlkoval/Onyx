import React, { useContext, useState, useEffect } from 'react'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedTeam } from '../../Models/Teams/IDetailedTeam';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table'
import { LoadingComponent } from '../General/Loading/LoadingComponent';
import { Container, Segment, Header, Divider, Button, Icon } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { Formik, FormikProps, FieldArray } from 'formik';
import { values } from 'mobx';
import { handleDate, handleGender } from '../../Utility/UtilityFunctions';

interface IProps {
    id: string;
}

const TeamForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {


    const root = useContext(RootStoreContext);
    const {createTeam, editTeam, loadTeam} = root.teamStore;
    const {openModal,} = root.modalStore;

    const [team, setTeam] = useState(new DetailedTeam());
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        if(match.params.id !== undefined) {
            setLoading(true);
            loadTeam(match.params.id).then((data) => {
                setTeam(new DetailedTeam(data));
            }).finally(() => {
                setLoading(false);
            })
        }
        setLoading(false);
    }, [loadTeam, match.params.id])

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Team</Header>
                <Formik onSubmit={(values) => console.log(values)} initialValues={team}>
                    {(props: FormikProps<any>) => (
                        <Form onSubmit={props.handleSubmit}>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Name</Form.Label>
                                    <Form.Control type="text" name="name" value={props.values.name} onChange={props.handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Date Created</Form.Label>
                                    <Form.Control type="date" name="creationDate" value={handleDate(team.creationDate)} onChange={props.handleChange}/>
                                </Form.Group>
                                {team.archiveDate !== null ? 
                                    <Form.Group as={Col}>
                                    <Form.Label>Date Created</Form.Label>
                                    <Form.Control type="date" name="archiveDate" value={handleDate(team.archiveDate)} onChange={props.handleChange}/>
                                </Form.Group> : null}
                            </Form.Row>
                        <Divider />
                        <Segment clearing>
                            <Header floated="left">Athletes</Header>
                            <Button positive content="Add Athlete" floated="right" type="button"/>
                        
                            {team.athletes !== null ? 
                            
                                <Table striped bordered hover>
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <FieldArray name="athletes" render={athleteHelpers => (team.athletes!.map((athlete, index) => 
                                        (
                                            <tr key={athlete.id}>
                                                <td>{athlete.name}</td>
                                                <td>{handleGender(athlete.gender)}</td>
                                                <td>
                                                    <Button floated="right" type="button" onClick={() => athleteHelpers.remove(index)}>
                                                        <Icon name="user times"/>
                                                    </Button>
                                                    <Button floated="right" type="button">
                                                        <Icon name="envelope"/>
                                                    </Button>
                                                </td>
                                            </tr>
                                        ))
                                    )} />
                                    </tbody>
                                </Table>
                            
                            : null}
                        </Segment>
                        <Divider />
                        <Segment clearing>
                            <Header floated="left">Coaches</Header>
                            <Button positive content="Add Coach" floated="right" type="button"/>
                        
                            {team.coaches !== null ? 
                            
                            <Table striped bordered hover>
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Gender</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <FieldArray name="athletes" render={arrayHelpers => (team.coaches!.map((coach, index) => 
                                (
                                    <tr key={coach.id}>
                                        <td>{coach.name}</td>
                                        <td>{handleGender(coach.gender)}</td>
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
                            )} />
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
                    )}
                </Formik>
            </Segment>
        </Container>
    )
}

export default observer(TeamForm)
