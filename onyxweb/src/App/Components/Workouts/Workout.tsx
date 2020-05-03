import React, { useEffect } from 'react'
import { observer } from 'mobx-react-lite'
import { RouteComponentProps } from 'react-router-dom'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from "@fullcalendar/interaction";

interface DetailParams {
    id: string
}

const Workout : React.FC<RouteComponentProps<DetailParams>> = ({match, history}) => {

    useEffect(() => {
        console.log("In here");
        if(match.params.id) {

        }
    }, [match.params.id])

    return (
        <Container>
        <Segment clearing>
                <Header style={{display: 'inline'}}>My Workouts</Header>
                <Button color='blue' floated='right' content="Add Class"></Button>
        </Segment>
        <Segment>
        <FullCalendar defaultView='dayGridWeek'  plugins={[dayGridPlugin, interactionPlugin]} weekends={true} 
        events={[{ title: 'event 1', date: '2020-04-24T16:00:00' }, { title: 'event 2', date: '2020-04-24T18:00:00' }]} />
        </Segment>
    </Container>
    )
}

export default observer(Workout)
