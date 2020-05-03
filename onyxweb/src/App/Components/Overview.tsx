import React, { useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Messages from './Overview/Messages'
import { Grid } from 'semantic-ui-react'
import { MessageStoreContext } from '../Stores/MessageStore'
import { MembershipShoreContext } from '../Stores/MembershipStore'
import Memberships from './Memberships/Memberships'
import Progress from './Overview/Progress'

const Overview : React.FC = () => {

    const messageStore = useContext(MessageStoreContext);
    const memberStore = useContext(MembershipShoreContext);
    const {loadMessages} = messageStore;
    const {loadMemberships} = memberStore;

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

