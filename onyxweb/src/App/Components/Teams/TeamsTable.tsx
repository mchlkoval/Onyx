import React from 'react'
import { observer } from 'mobx-react-lite'
import Table from 'react-bootstrap/Table'
import { ITeams } from '../../Models/Teams/ITeams'
import { handleDate } from '../../Utility/UtilityFunctions'
import { Button, Icon } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

interface IProps {
    state: string;
    teams: ITeams[];
}

const TeamsTable : React.FC<IProps> = ({state, teams}) => {
    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Date Created</th>
                    {state === "archived" ? <th>Date Archived</th> : null} 
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {teams.map(team => (
                    <tr key={team.id}>
                        <td>{team.name}</td>
                        <td>{handleDate(team.creationDate)}</td>
                        {state === "archived" ? <td>{handleDate(team.archiveDate)}</td> : null}
                        <td>
                            <Button floated="right" as={Link} to={`/teams/edit/${team.id}`}>
                                <Icon name="pencil" />
                            </Button>
                            <Button floated="right">
                                <Icon name="envelope" />
                            </Button>
                            <Button floated="right">
                                <Icon name={state === "archived" ? "user plus" : "user times"} />
                            </Button>
                        </td> 
                    </tr>
                ))}
            </tbody>
        </Table>
    )
}

export default observer(TeamsTable)
