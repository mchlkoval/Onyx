import React, { useContext, useEffect, useState } from 'react'
import { RootStoreContext } from '../../../Stores/RootStore';
import { ITeamMembers } from '../../../Models/Teams/ITeams';
import Spinner from 'react-bootstrap/Spinner';
import { Segment, Header, Button, Icon } from 'semantic-ui-react';
import Table from 'react-bootstrap/Table'
import { handleGender } from '../../../Utility/UtilityFunctions';

interface IProps {
    teamId: string,
    orgId: string,
    isCoach: boolean,
    handleSelectMember : (member: ITeamMembers, isCoach : boolean) => void
}

const AvailableTeamMembers : React.FC<IProps> = ({teamId, orgId, isCoach, handleSelectMember}) => {

    const rootStore = useContext(RootStoreContext);
    const {loadAvailableMembers, handleAddingAvailableTeamMember} = rootStore.teamStore;

    const [members, setMembers] = useState<Array<ITeamMembers>>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadAvailableMembers(teamId, orgId, isCoach)
        .then((data) => {
            if(data !== undefined) {
                setMembers(data);
            }
        }).finally(() => setLoading(false));
    }, [loadAvailableMembers, teamId, orgId, isCoach])

    const handleAddMemberClicked = async (member: ITeamMembers) => {
        var indexToRemove = members.indexOf(member);
        setMembers(members.filter((x, index) => index !== indexToRemove))
        await handleAddingAvailableTeamMember(member, isCoach).then(() => {
            handleSelectMember(member, isCoach);
        });
    }

    if(loading) {
        return <Spinner animation="border" role="status">
            <span className="sr-only">Loading...</span>
        </Spinner>
    }

    
    return (
        <Segment clearing>
            <Header as='h3'>Available {isCoach ? "Coaches" : "Athletes"}</Header>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Gender</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {members.map((member) => (
                        <tr key={member.id}>
                            <td>{member.name}</td>
                            <td>{handleGender(member.gender)}</td>
                            <td>
                            <Button floated="right" type="button" onClick={() => handleAddMemberClicked(member)}>
                                <Icon name="user plus"/>
                            </Button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </Table>
        </Segment>
    )
}

export default AvailableTeamMembers
