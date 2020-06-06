import React, { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Table from 'react-bootstrap/Table'
import { Link } from 'react-router-dom'
import { Button, Icon } from 'semantic-ui-react'
import { ICoaches } from '../../Models/Coaches/ICoaches'

interface IProps {
    state : string
    coaches : ICoaches[]
    messageCoach : (id: string, name: string) => void,
    archiveCoach? : (id: string, name: string) => void,
    activateCoach? : (id : string, name : string) => void
}

const CoachesTable : React.FC<IProps> = ({state, coaches, messageCoach, archiveCoach, activateCoach}) => {

    useEffect(() => {

    }, [])

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Date Employed</th>  
                    {state === "archived" ? <th>Date Archived</th> : null}
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {coaches.map(coach => (
                    <tr key={coach.id}>
                        <td>{coach.name}</td>
                        <td>{new Date(coach.dateHired).toISOString().split('T')[0]}</td>
                        {state === "archived" ? <td>{new Date(coach.dateArchived!).toISOString().split('T')[0]}</td> : null}
                        <td>
                            <Button floated="right" as={Link} to={`/coaches/edit/${coach.id}`}>
                                <Icon name="pencil" />
                            </Button>
                            <Button floated="right" onClick={() => messageCoach(coach.id, coach.name)}>
                                <Icon name="envelope" />
                            </Button>
                            <Button floated="right" onClick={() => {
                                if(state === "active")
                                    archiveCoach!(coach.id, coach.name)
                                else
                                    activateCoach!(coach.id, coach.name)
                                }}>
                                <Icon name={state === "archived" ? "user plus" : "user times"} />
                            </Button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
    )
}

export default observer(CoachesTable)
