import React, { useEffect, useContext } from 'react'
import { observer } from 'mobx-react-lite'
import { Container, Label, Icon, Segment } from 'semantic-ui-react'
import { RootStoreContext } from '../../Stores/RootStore';
import Table from 'react-bootstrap/Table'
import { GenderType } from '../../Models/Enums/Gender';

const AthletesList = () => {
    
    const rootStore = useContext(RootStoreContext);
    const {listAthletes, athletes} = rootStore.athleteStore;

    useEffect(() => {
        listAthletes(true);
    }, [listAthletes]) 

    const handleGenderEnum = (gender : GenderType) => {
        if(gender === 0) {
            return "Male";
        } else if (gender === 1) {
            return "Female";
        } else {
            return "Other";
        }
    }

    return (
        <Container>
            <Segment>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Gender</th>
                            <th>Date Joined</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {athletes.map(athlete => (
                            <tr>
                                <td>{athlete.name}</td>
                                <td>{handleGenderEnum(athlete.gender)}</td>
                                <td>{new Date(athlete.dateJoined).toISOString().split('T')[0]}</td>
                                <td>
                                    <Label>
                                        <Icon name="pencil"/>
                                    </Label>
                                    <Label>
                                        <Icon name="envelope" />
                                    </Label>
                                    <Label>
                                        <Icon name="trash" />
                                    </Label>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </Segment>
        </Container>
    )
}

export default observer(AthletesList)
