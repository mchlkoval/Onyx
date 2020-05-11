import React, { useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Messages from './Overview/Messages'
import { Grid } from 'semantic-ui-react'
import { MessageStoreContext } from '../Stores/MessageStore'
import Memberships from './Memberships/Memberships'
import Progress from './Overview/Progress'
import { RootStoreContext } from '../Stores/RootStore'

const Overview : React.FC = () => {

    const messageStore = useContext(MessageStoreContext);
    const root = useContext(RootStoreContext);    
    const {loadMessages} = messageStore;
    const {loadMemberships} = root.membershipStore;

    useEffect(() => {
        loadMessages();
        loadMemberships();
    }, [loadMessages, loadMemberships])

    return (
        <Grid columns={2} divided inverted>
            <Grid.Row>
                <Grid.Column>
                    <Messages />
                </Grid.Column>
                <Grid.Column>
                    <Memberships />
                </Grid.Column>
            </Grid.Row>
            <Grid.Row>
                <Grid.Column>
                    <Progress />
                </Grid.Column>
            </Grid.Row>
        </Grid>
           

    )
}

export default observer(Overview)

