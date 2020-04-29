import React, { useContext, Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { MessageStoreContext } from '../../Stores/MessageStore';
import { Segment, Message, Header, Container, Table, Label, Icon } from 'semantic-ui-react';

const Messages : React.FC = () => {

    const messageStore = useContext(MessageStoreContext);
    const {messages} = messageStore;

    return (
        <Fragment>
            <Container>
                <Segment>
                    <Header>Messages</Header>
                    <Table striped>
                        <Table.Header>
                            <Table.Row>
                                <Table.HeaderCell>From</Table.HeaderCell>
                                <Table.HeaderCell>Date</Table.HeaderCell>
                                <Table.HeaderCell>Content</Table.HeaderCell>
                                <Table.HeaderCell>Actions</Table.HeaderCell>
                            </Table.Row>
                            {messages.map(m => (
                                <Table.Row key={m.id}>
                                    <Table.Cell>{m.from}</Table.Cell>
                                    <Table.Cell>{new Date(m.dateOfMessage).toISOString().split('T')[0]}</Table.Cell>
                                    <Table.Cell>{m.content}</Table.Cell>
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
                        </Table.Header>
                    </Table>
                </Segment>
            </Container>
        </Fragment>
    )
}

export default observer(Messages)
