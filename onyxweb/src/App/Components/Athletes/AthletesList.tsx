import React, { useEffect, useContext, useState } from 'react'
import { observer } from 'mobx-react-lite'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { Container, Segment } from 'semantic-ui-react'
import { RootStoreContext } from '../../Stores/RootStore';
import { GenderType } from '../../Models/Enums/Gender';
import AthleteTable from './AthleteTable'

const AthletesList = () => {
    
    const rootStore = useContext(RootStoreContext);
    const {listAthletes, athletes} = rootStore.athleteStore;

    const [key, setKey] = useState('active');
    const [active, setFilter] = useState(true);

    useEffect(() => {
        listAthletes(active);
    }, [listAthletes, active]) 

    
    const handleGenderEnum = (gender : GenderType) => {
        if(gender === 0) {
            return "Male";
        } else if (gender === 1) {
            return "Female";
        } else {
            return "Other";
        }
    }
    
    const messageAthlete = (id: string) => {
        alert(`Athlete to message is: ${id}`);
    }
    
    const editAthlete = (id: string) => {
        alert(`Athlete to edit: ${id}`);
    }
    
    const archiveAthlete = (id: string) => {
        alert(`Athlete to archive: ${id}`);
    }

    return (
        <Container>
            <Segment>
                <Tabs fill defaultActiveKey="active" id="controlled-tab" activeKey={key} onSelect={(k : string) => {
                    
                    setFilter(k === "active" ? true : false);
                    setKey(k);
                }}>
                    <Tab eventKey="active" title="Active">
                        <AthleteTable athletes={athletes} editAthlete={editAthlete} messageAthlete={messageAthlete} archiveAthlete={archiveAthlete} handleGenderEnum={handleGenderEnum} state={key}/>
                    </Tab>
                    <Tab eventKey="archived" title="Archived">
                        <AthleteTable athletes={athletes} editAthlete={editAthlete} messageAthlete={messageAthlete} archiveAthlete={archiveAthlete} handleGenderEnum={handleGenderEnum} state={key}/>
                    </Tab>
                </Tabs>
                {/* <Table striped bordered hover>
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
                            <tr key={athlete.id}>
                                <td>{athlete.name}</td>
                                <td>{handleGenderEnum(athlete.gender)}</td>
                                <td>{new Date(athlete.dateJoined).toISOString().split('T')[0]}</td>
                                <td>
                                    <Button floated="right" onClick={() => editAthlete(athlete.id)}>
                                        <Icon name="pencil" />
                                    </Button>
                                    <Button floated="right" onClick={() => messageAthlete(athlete.id)}>
                                        <Icon name="envelope" />
                                    </Button>
                                    <Button floated="right" onClick={() => archiveAthlete(athlete.id)}>
                                        <Icon name="trash" />
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table> */}
            </Segment>
        </Container>
    )
}

export default observer(AthletesList)
