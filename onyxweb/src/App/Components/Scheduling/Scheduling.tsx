import React from 'react'
import { observer } from 'mobx-react-lite'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import ClassCalendar from './ClassCalendar'

const Scheduling : React.FC = () => {
    return (
        <Container>
            <Segment clearing>
                    <Header style={{display: 'inline'}}>My Schedule</Header>
                    <Button color='blue' floated='right' content="Add Class"></Button>
            </Segment>
            <Segment>
                <ClassCalendar />
            </Segment>
        </Container>
    )
}

export default  observer(Scheduling)
