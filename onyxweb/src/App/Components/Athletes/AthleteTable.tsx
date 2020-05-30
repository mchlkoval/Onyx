import React, { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Table from 'react-bootstrap/Table'
import { Button, Icon } from 'semantic-ui-react'
import { GenderType } from '../../Models/Enums/Gender'
import { Athletes } from '../../Models/Athlete/Athletes'
import { Link } from 'react-router-dom'

interface IProps {
    handleGenderEnum : (gender : GenderType) => string,
    messageAthlete : (id: string, name: string) => void,
    archiveAthlete? : (id: string, name: string) => void,
    activateAthlete? : (id : string, name : string) => void
    athletes : Athletes[]
    state : string
}

const AthleteTable : React.FC<IProps> = ({handleGenderEnum, messageAthlete, archiveAthlete, activateAthlete, athletes, state}) => {

    useEffect(() => {

    }, [])

    return (
        <Table striped bordered hover>
            <thead>
                <tr>
                    <th>Name</th>
                    <th>Gender</th>
                    <th>Date Joined</th>
                    {state === "archived" ? <th>Date Archived</th> : null}
                    <th>Actions</th>
                </tr>
            </thead>
            <tbody>
                {athletes.map(athlete => (
                    <tr key={athlete.id}>
                        <td>{athlete.name}</td>
                        <td>{handleGenderEnum(athlete.gender)}</td>
                        <td>{new Date(athlete.dateJoined).toISOString().split('T')[0]}</td>
                        {state === "archived" ? <td>{new Date(athlete.dateArchived!).toISOString().split('T')[0]}</td> : null}
                        <td>
                            <Button floated="right" as={Link} to={`/athletes/edit/${athlete.id}`}>
                                <Icon name="pencil" />
                            </Button>
                            <Button floated="right" onClick={() => messageAthlete(athlete.id, athlete.name)}>
                                <Icon name="envelope" />
                            </Button>
                            <Button floated="right" onClick={() => {
                                if(state === "active")
                                    archiveAthlete!(athlete.id, athlete.name)
                                else
                                    activateAthlete!(athlete.id, athlete.name)
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

export default observer(AthleteTable)
