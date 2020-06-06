import React, { useEffect, useContext, useState } from 'react'
import { observer } from 'mobx-react-lite'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { Container, Segment, Search, Header, Divider } from 'semantic-ui-react'
import { RootStoreContext } from '../../Stores/RootStore';
import { GenderType } from '../../Models/Enums/Gender';
import AthleteTable from './AthleteTable'
import { Athletes } from '../../Models/Athlete/Athletes'
import ArchiveAthleteModal from './Modals/ArchiveAthleteModal'
import ReactivateAthleteModal from './Modals/ReactivateAthleteModal'
import MessageAthleteModal from './Modals/MessageAthleteModal'

const AthletesList = () => {
    
    const rootStore = useContext(RootStoreContext);
    const {listAthletes, athletes, activeAthletes, archivedAthletes} = rootStore.athleteStore;
    const {openModal} = rootStore.modalStore;

    const [key, setKey] = useState('active');
    // const [filteredAthletes, updateFilteredAthletes] = useState(athletes);
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
    
    const messageAthlete = (id: string, name: string) => {
        openModal(<MessageAthleteModal id={id} name={name} />);
    }
    
    const archiveAthlete = (id: string, name: string) => {
        openModal(<ArchiveAthleteModal id={id} name={name}/>);
    }

    const reactivateAthlete = (id: string, name: string) => {
        openModal(<ReactivateAthleteModal id={id} name={name} />);
    }

    const handleChange = (value:string | undefined, filter? : string) => {

        let localActive = true;
        let result : Athletes[] = [];
        
        if(filter) {
            localActive = filter === "active" ? true : false;
        }

        if(value === "" || value === undefined) {
            result = athletes.filter((athlete) => athlete.isActive === localActive);
            //updateFilteredAthletes(result);
            return;
        }

        result = athletes.filter((athlete) => {
            return (athlete.name.toLowerCase().indexOf(value!.toLowerCase()) !== -1 || value!.toLowerCase() === "")
        });
        
        //updateFilteredAthletes(result);
    }

    return (
        <Container>
            <Segment clearing>
                <Header as="h3" floated="left" textAlign="center">Search For Athletes</Header>
                <Search style={{float: 'right'}} onSearchChange={(e, {value}) => handleChange(value)}/>
            </Segment>
            <Divider />
            <Segment>
                
                <Tabs fill defaultActiveKey="active" id="controlled-tab" activeKey={key} onSelect={(k : string) => {
                    setFilter(k === "active" ? true : false);
                    setKey(k);
                }}>
                    <Tab eventKey="active" title="Active">
                        <AthleteTable athletes={activeAthletes} messageAthlete={messageAthlete} archiveAthlete={archiveAthlete} handleGenderEnum={handleGenderEnum} state={key}/>
                    </Tab>
                    <Tab eventKey="archived" title="Archived">
                        <AthleteTable athletes={archivedAthletes} messageAthlete={messageAthlete} activateAthlete={reactivateAthlete} handleGenderEnum={handleGenderEnum} state={key}/>
                    </Tab>
                </Tabs>
            </Segment>
        </Container>
    )
}

export default observer(AthletesList)
