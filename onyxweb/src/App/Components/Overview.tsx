import React, { useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Messages from './Overview/Messages'
import { Grid } from 'semantic-ui-react'
import Memberships from './Memberships/Memberships'
import Progress from './Overview/Progress'
import { RootStoreContext } from '../Stores/RootStore'

const Overview : React.FC = () => {

    const root = useContext(RootStoreContext);    
    const {loadMemberships} = root.membershipStore;

    useEffect(() => {
        loadMemberships();
    }, [loadMemberships])

    return (
        <Grid columns={2} divided inverted>
            <Grid.Row columns={1}>
                <Grid.Column>
                    <Messages />
                </Grid.Column>
            </Grid.Row>
            <Grid.Row>
                <Grid.Column>
                    <Progress />
                </Grid.Column>
                <Grid.Column>
                    <Memberships />
                </Grid.Column>
            </Grid.Row>
        </Grid>
           

    )
}

export default observer(Overview)

