import React, { useContext, useState, useEffect } from 'react'
import { RouteComponentProps } from 'react-router-dom'
import { RootStoreContext } from '../../Stores/RootStore';
import { DetailedTeam, IDetailedTeam } from '../../Models/Teams/IDetailedTeam';
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table'
import { LoadingComponent } from '../General/Loading/LoadingComponent';
import { Container, Segment, Header, Divider, Button, Icon } from 'semantic-ui-react';
import { observer } from 'mobx-react-lite';
import { Formik, FieldArray } from 'formik';
import { handleDate, handleGender } from '../../Utility/UtilityFunctions';
import MessageAthleteModal from '../Athletes/Modals/MessageAthleteModal';
import MessageCoachModal from '../Coaches/Modals/MessageCoachModal';
import TeamMembers from './TeamMembers';
import AvailableTeamMembers from './Modals/AvailableTeamMembers';
import { ITeamMembers } from '../../Models/Teams/ITeams';

interface IProps {
    id: string;
}

const TeamForm : React.FC<RouteComponentProps<IProps>> = ({match, history}) => {


    const root = useContext(RootStoreContext);
    const {createTeam, editTeam, loadTeam} = root.teamStore;
    const {openModal} = root.modalStore;
    const {user} = root.userStore;

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

    const messageAthlete = (id: string, name: string) => {
        openModal(<MessageAthleteModal id={id} name={name} />);
    }

    const messageCoach = (id: string, name: string) => {
        openModal(<MessageCoachModal id={id} name={name} />);
    }

    const handleSubmit = (values: IDetailedTeam) => {
        if(team.id !== undefined || team.id !== null) {
            createTeam(values);
        } else {
            editTeam(values);
        }
    }

    const handleAddingMember = (member: ITeamMembers, isCoach : boolean) => {
        
        if(isCoach)
            team?.coaches.push(member) 
        else 
            team?.athletes.push(member);
        
        setTeam(new DetailedTeam(team));
    }

    if(loading) {
        return <LoadingComponent content="Loading ..."/>
    }

    return (
        <Container>
            <Segment clearing>
                <Header>Manage Team</Header>
                <Formik onSubmit={(values) => handleSubmit(values)} initialValues={team} 
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
                                    <Form.Label>Date Archived</Form.Label>
                                    <Form.Control readOnly type="date" name="archiveDate" value={handleDate(values.archiveDate!)} onChange={handleChange}/>
                                </Form.Group> : null}
                            </Form.Row>
                        <Divider />
                        <Segment clearing>
                            <Header floated="left">Athletes</Header>
                            <Button positive content="Add Athlete" floated="right" type="button" onClick={() => openModal(<AvailableTeamMembers handleSelectMember={handleAddingMember} teamId={match.params.id} orgId={user!.orgId} isCoach={false}/>)}/>
                            {values.athletes !== null ? <TeamMembers fieldArrayName="athletes" teamMembers={values.athletes} openModal={messageAthlete} /> : null}
                        </Segment>
                        <Divider />
                        <Segment clearing>
                            <Header floated="left">Coaches</Header>
                            <Button positive content="Add Coach" floated="right" type="button" onClick={() => openModal(<AvailableTeamMembers handleSelectMember={handleAddingMember} teamId={match.params.id} orgId={user!.orgId} isCoach={true}/>)}/>
                            {values.coaches !== null ?  <TeamMembers fieldArrayName="coaches" teamMembers={values.coaches} openModal={messageCoach} /> : null}
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
