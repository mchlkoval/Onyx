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
import MessageAthleteModal from '../Athletes/Modals/MessageAthleteModal';
import MessageCoachModal from '../Coaches/Modals/MessageCoachModal';

interface IProps {
    id: string;
}

const TeamForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {


    const root = useContext(RootStoreContext);
    const {createTeam, editTeam, loadTeam} = root.teamStore;
    const {openModal} = root.modalStore;

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
   
    }, [loadTeam, match.params])

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Team</Header>
                <Formik onSubmit={(values) => console.log(values)} initialValues={team} 
                render = {
                    ({values, handleChange, handleSubmit}) => (
                        <Form onSubmit={handleSubmit}>
                            <Form.Row>
                                <Form.Group as={Col}>
                                    <Form.Label>Name</Form.Label>
                                    <Form.Control type='text' name="name" value={values.name} onChange={handleChange}/>
                                </Form.Group>
                                <Form.Group as={Col}>
                                    <Form.Label>Date Created</Form.Label>
                                    <Form.Control type="date" name="creationDate" value={handleDate(values.creationDate)} onChange={handleChange}/>
                                </Form.Group>
                                {team.archiveDate !== null ? 
                                    <Form.Group as={Col}>
                                    <Form.Label>Date Created</Form.Label>
                                    <Form.Control type="date" name="archiveDate" value={handleDate(values.archiveDate!)} onChange={handleChange}/>
                                </Form.Group> : null}
                            </Form.Row>
                        <Divider />
                        <Segment clearing>
                            <Header floated="left">Athletes</Header>
                            <Button positive content="Add Athlete" floated="right" type="button"/>
                        
                            {values.athletes !== null ? 
                            
                                <Table striped bordered hover>
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>Gender</th>
                                            <th>Actions</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <FieldArray name="athletes" render={athleteHelpers => (values.athletes!.map((athlete, index) => 
                                        (
                                            <tr key={athlete.id}>
                                                <td>{athlete.name}</td>
                                                <td>{handleGender(athlete.gender)}</td>
                                                <td>
                                                    <Button floated="right" type="button" onClick={() => athleteHelpers.remove(index)}>
                                                        <Icon name="user times"/>
                                                    </Button>
                                                    <Button floated="right" type="button" onClick={() => openModal(<MessageAthleteModal id={athlete.id} name={athlete.name}/>)}>
                                                        <Icon key={`${index}_${athlete.id}`} name="envelope" />
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
                        
                            {values.coaches !== null ? 
                            
                            <Table striped bordered hover>
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Gender</th>
                                    <th>Actions</th>
                                </tr>
                            </thead>
                            <tbody>
                                <FieldArray name="athletes" render={arrayHelpers => (values.coaches!.map((coach, index) => 
                                (
                                    <tr key={coach.id}>
                                        <td>{coach.name}</td>
                                        <td>{handleGender(coach.gender)}</td>
                                        <td>
                                            <Button floated="right" type="button" onClick={() => arrayHelpers.remove(index)}>
                                                <Icon name="user times"/>
                                            </Button>
                                            <Button floated="right" type="button" onClick={() => openModal(<MessageCoachModal id={coach.id} name={coach.name}/>)}>
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
                    )
                }/>
            </Segment>
        </Container>
    )
}

export default observer(TeamForm)
