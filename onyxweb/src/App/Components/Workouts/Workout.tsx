import React, { useEffect, useContext} from 'react'
import { observer } from 'mobx-react-lite'
import { Container, Segment, Header, Button } from 'semantic-ui-react'
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from "@fullcalendar/interaction";
import ProgressBar from 'react-bootstrap/ProgressBar'
import { RootStoreContext } from '../../Stores/RootStore'
import { history } from '../../..'


const Workout : React.FC = () => {

    const root = useContext(RootStoreContext);
    const {getWorkouts, events} = root.workoutStore;

    useEffect(() => {
        getWorkouts();
    }, [getWorkouts])

    const handleEventClick = (arg: any) => {
        history.push(`/workout/${arg.event.id}`)
    }

    return (
        <Container>
        <Segment clearing>
                <Header style={{display: 'inline-block'}}>Weekly Workout Progress</Header>
                <ProgressBar now={60} style={{marginBottom: '10px'}}/>
                <Button color='blue' floated='right' content="Add Workout"></Button>
        </Segment>
        <Segment>
        <FullCalendar defaultView='dayGridWeek' plugins={[dayGridPlugin, interactionPlugin]} weekends={true} 
        events={events} eventClick={handleEventClick} />
        </Segment>
    </Container>
    )
}

export default observer(Workout)
