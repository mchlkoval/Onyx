import React, { useContext, useState, useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import Table from 'react-bootstrap/Table'
import { Button, Icon, Container, Segment, Header } from 'semantic-ui-react';
import { handleDate } from '../../Utility/UtilityFunctions';
import { Message } from '../../Models/Message';
import Spinner from 'react-bootstrap/Spinner'
import { RootStoreContext } from '../../Stores/RootStore';
import MessageCenter from '../MessagingCenter/MessageCenter';

const Messages : React.FC = () => {

    const rootStore = useContext(RootStoreContext);
    const {loadMessages} = rootStore.messageStore;
    const {openModal} = rootStore.modalStore;

    const [messages, setMessages] = useState<Array<Message>>([])
    const [loading, setLoading] = useState(true);
    
    useEffect(() => {
        loadMessages().then((data) => {
            if(data !== undefined) {
                setMessages(data);
            }
        }).finally(() => setLoading(false));
    }, [loadMessages])

    if(loading) {
        return <Spinner animation="border" role="status">
            <span className="sr-only">Loading Messages...</span>
        </Spinner>
    }

    return (
        <Container>
            <Segment clearing>
                <div className="tableDescription">
                    <Header as="h3" floated="left">Messaging Center</Header>
                    <Button floated="right" content="Manage" positive 
                        onClick={() => openModal(<MessageCenter />)}
                    />
                </div>
                <Table striped bordered hover>
                    <thead>
                        <tr>
                            <th>From</th>
                            <th>Date</th>
                            <th>Content</th>
                            <th>Actions</th>
                        </tr>
                    </thead>
                    <tbody>
                        {messages.map((message) => (
                            <tr key={message.id}>
                                <td>{message.from}</td>
                                <td>{handleDate(message.dateOfMessage)}</td>
                                <td>{message.content}</td>
                                <td>
                                    <Button floated="right" type="button">
                                        <Icon name='trash' />
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                    
                </Table>
            </Segment>
        </Container>
    )
}

export default observer(Messages)
