import React, { useState, useContext, useEffect } from 'react'
import { Container, Segment, Header, Search, Divider, Button } from 'semantic-ui-react'
import { Link } from 'react-router-dom'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { observer } from 'mobx-react-lite'
import { RootStoreContext } from '../../Stores/RootStore'
import TeamsTable from './TeamsTable'

const TeamsList = () => {


    const rootStore = useContext(RootStoreContext);
    const {loadTeams, activeTeams, inactiveTeams} = rootStore.teamStore;
    const [key, setKey] = useState('active');

    useEffect(() => {
        loadTeams("3c084a85-e680-40c1-9c2c-d5839286ec67")
    }, [loadTeams]);

    useEffect(() => {}, [key]);

    return (
        <Container>
            <Segment clearing>
                <Header as="h3" floated="left" textAlign="center">Search For Teams</Header>
                <Search style={{float: 'right'}} />
            </Segment>
            <Divider />
            <Segment>
                <Segment clearing>
                    <Button as={Link} to="/teams/create" positive floated="right">Create</Button>
                </Segment>
                <Tabs fill defaultActiveKey="athletes" id="teams-tab" activeKey={key} onSelect={(k : string) => {
                    setKey(k);
                }}>
                    <Tab eventKey="active" title="Active">
                        <TeamsTable state={key} teams={activeTeams}/>
                    </Tab>
                    <Tab eventKey="archived" title="Archived">
                        <TeamsTable state={key} teams={inactiveTeams}/>
                    </Tab>
                </Tabs>
            </Segment>

        </Container>
    )
}

export default observer(TeamsList)
