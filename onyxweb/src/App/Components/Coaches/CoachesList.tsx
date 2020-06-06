import React, { useContext, useState, useEffect } from 'react'
import { RootStoreContext } from '../../Stores/RootStore';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { Container, Segment, Header, Search, Divider } from 'semantic-ui-react';
import CoachesTable from './CoachesTable';
import MessageCoachModal from './Modals/MessageCoachModal';
import { observer } from 'mobx-react-lite';
import ArchiveCoachModal from './Modals/ArchiveCoachModal';
import ReactivateCoachModal from './Modals/ReactivateCoachModal';

const CoachesList = () => {

    const rootStore = useContext(RootStoreContext);
    const {activeCoaches, archivedCoaches, loadCoaches} = rootStore.coachStore;
    const {openModal} = rootStore.modalStore;

    const [key, setKey] = useState('active');
    const [active, setFilter] = useState(true);
    
    useEffect(() => {
        loadCoaches(active).then((data) => {
            console.log("data: ", data);
        });
    }, [loadCoaches, active])

    const messageCoach = (id: string, name: string) => {
        openModal(<MessageCoachModal id={id} name={name}/>)
    }

    const archiveCoach = (id: string, name: string) => {
        openModal(<ArchiveCoachModal id={id} name={name}/>)
    }

    const reactivateCoach = (id: string, name: string) => {
        openModal(<ReactivateCoachModal id={id} name={name}/>)
    }

    return (
        <Container>
            <Segment clearing>
                <Header as="h3" floated="left" textAlign="center">Search For Coaches</Header>
                <Search style={{float: 'right'}} />
            </Segment>
            <Divider />
            <Segment>
                <Tabs fill defaultActiveKey="active" id="controlled-tab" activeKey={key} onSelect={(k : string) => {
                    setFilter(k === "active" ? true : false);
                    setKey(k);;
                }}>
                    <Tab eventKey="active" title="Active">
                        <CoachesTable coaches={activeCoaches} state={key} messageCoach={messageCoach} archiveCoach={archiveCoach} activateCoach={reactivateCoach}/>
                    </Tab>
                    <Tab eventKey="archived" title="Archived">
                        <CoachesTable coaches={archivedCoaches} state={key} messageCoach={messageCoach} archiveCoach={archiveCoach} activateCoach={reactivateCoach}/>
                    </Tab>
                </Tabs>
            </Segment>
        </Container>
    )
}

export default observer(CoachesList)
