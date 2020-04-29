import React, { Fragment, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { Container, Segment, Header, Table, Label, Icon, Button} from 'semantic-ui-react'
import { MembershipShoreContext } from '../../Stores/MembershipStore';
import { RootStoreContext } from '../../Stores/RootStore';
import Workouts from '../Workouts/Workouts';

const VerboseMembership : React.FC = () => {

    const membershipStore = useContext(MembershipShoreContext);
    const root = useContext(RootStoreContext);
    const {verboseMemberships, loadVerboseMemberships} = membershipStore;
    const {openModal} = root.modalStore;

    useEffect(() => {
        loadVerboseMemberships()
    }, [loadVerboseMemberships])

    return (
        <Fragment>
            <Container>
            <Segment clearing>
                    <Header>Available Memberships</Header>
                    <Table striped celled>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>Name</Table.HeaderCell>
                                <Table.HeaderCell>Description</Table.HeaderCell>
                                <Table.HeaderCell>Cost</Table.HeaderCell>
                                <Table.HeaderCell textAlign='center'>Actions</Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>
                        <Table.Body>
                            {verboseMemberships.map(m => (
                                <Table.Row key={m.id}>
                                    <Table.Cell>{m.name}</Table.Cell>
                                    <Table.Cell>{m.description}</Table.Cell>
                                    <Table.Cell>${m.cost}</Table.Cell>
                                    <Table.Cell textAlign='center'>
                                        <Button color='blue' content="View Workouts" onClick={() => openModal(<Workouts workouts={m.workouts}/>)} />
                                        <Button positive content='Purchase' />
                                    </Table.Cell>
                                </Table.Row>                
                            ))}
                            
                        </Table.Body>
                        
                    </Table>
                </Segment>
            </Container>
        </Fragment>
    )
}

export default observer(VerboseMembership)
