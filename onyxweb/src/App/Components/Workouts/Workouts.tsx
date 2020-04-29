import React, { Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { Workout } from '../../Models/Workout'
import { Header, Table, Button } from 'semantic-ui-react'

interface IProps {
    workouts : Workout[]
}

const Workouts : React.FC<IProps> = ({workouts}) => {


    return (
            <Fragment>
                <Header>Workouts</Header>
                    <Table striped>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>Name</Table.HeaderCell>
                                <Table.HeaderCell>Description</Table.HeaderCell>
                                <Table.HeaderCell textAlign='right'>Actions</Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>
                        <Table.Body>
                            {workouts.map(w => (
                                <Table.Row key={w.id}>
                                    <Table.Cell>{w.name}</Table.Cell>
                                    <Table.Cell>{w.description}</Table.Cell>
                                    <Table.Cell textAlign='right'>
                                        <Button color='blue' content="Details" />
                                    </Table.Cell>
                                </Table.Row>
                            ))}
                        </Table.Body>
                    </Table>
            </Fragment>
)
}

export default observer(Workouts)
