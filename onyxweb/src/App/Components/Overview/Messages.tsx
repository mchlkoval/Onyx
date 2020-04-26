import React, { useContext, Fragment } from 'react'
import { observer } from 'mobx-react-lite'
import { MessageStoreContext } from '../../Stores/MessageStore';
import { Segment, Message, Header, Container } from 'semantic-ui-react';

const Messages : React.FC = () => {

    const messageStore = useContext(MessageStoreContext);
    const {messages} = messageStore;

    return (
        <Fragment>
            <Container>
                <Segment>
                    <Header>Messages</Header>
                    <Segment.Group>
                        {messages.map(message => (
                            <Segment key={message.id}>
                                <Message content={message.content} />
                            </Segment>
                        ))}
                    </Segment.Group>
                </Segment>
            </Container>
        </Fragment>
    )
}

export default observer(Messages)
