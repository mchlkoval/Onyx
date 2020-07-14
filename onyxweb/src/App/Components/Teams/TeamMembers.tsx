import React from 'react'
import { observer } from 'mobx-react-lite'
import { ITeamMembers } from '../../Models/Teams/ITeams'
import Form from 'react-bootstrap/Form'
import Col from 'react-bootstrap/Col';
import Table from 'react-bootstrap/Table'
import { FieldArray } from 'formik';
import {Button, Icon } from 'semantic-ui-react';
import { handleGender } from '../../Utility/UtilityFunctions';
import MessageAthleteModal from '../Athletes/Modals/MessageAthleteModal';

interface IProps {
    teamMembers : ITeamMembers[],
    fieldArrayName: string,
    openModal: (id: string, name: string) => void
}

const TeamMembers : React.FC<IProps> = ({teamMembers, fieldArrayName, openModal}) => {
    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Gender</th>
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                <FieldArray name={fieldArrayName} render={athleteHelpers => (teamMembers.map((teamMember, index) => 
                (
                    <tr key={teamMember.id}>
                        <td>{teamMember.name}</td>
                        <td>{handleGender(teamMember.gender)}</td>
                        <td>
                            <Button floated="right" type="button" onClick={() => athleteHelpers.remove(index)}>
                                <Icon name="user times"/>
                            </Button>
                            <Button floated="right" type="button" onClick={() => openModal(teamMember.id, teamMember.name)}>
                                <Icon key={`${index}_${teamMember.id}`} name="envelope" />
                            </Button>
                        </td>
                    </tr>
                ))
            )} />
            </tbody>
        </Table>
    )
}

export default observer(TeamMembers)
