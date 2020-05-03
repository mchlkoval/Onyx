import React, { useContext, Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { MembershipShoreContext } from '../../Stores/MembershipStore';
import { Container, Segment, Header,  Table, Label, Icon, } from 'semantic-ui-react';
import Jumbotron from 'react-bootstrap/Jumbotron'

const Memberships : React.FC = () => {

    const membershipStore = useContext(MembershipShoreContext);
    const {memberships} = membershipStore;

    return (
        <Fragment>
            <Container>
                <Segment clearing>
                    <Header>Memberships</Header>
                    <Table striped>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>Name</Table.HeaderCell>
                                <Table.HeaderCell>Description</Table.HeaderCell>
                                <Table.HeaderCell>Actions</Table.HeaderCell>
                            </Table.Row>
                        </Table.Header>
                        <Table.Body>
                            {memberships.map(m  => (
                                <Table.Row key={m.id}>
                                    <Table.Cell>{m.name}</Table.Cell>
                                    <Table.Cell>{m.description}</Table.Cell>
                                    <Table.Cell>
                                        <Label>
                                            <Icon name='pencil'/>
                                        </Label>
                                        <Label>
                                            <Icon name='trash'/>
                                        </Label>
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

export default observer(Memberships)
