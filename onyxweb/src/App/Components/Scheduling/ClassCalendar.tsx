import React, { useContext } from 'react'
import { observer } from 'mobx-react-lite'
import FullCalendar from '@fullcalendar/react'
import dayGridPlugin from '@fullcalendar/daygrid'
import interactionPlugin from "@fullcalendar/interaction";

import '@fullcalendar/core/main.css'
import '@fullcalendar/daygrid/main.css'
import { RootStoreContext } from '../../Stores/RootStore';
import AppointmentForm from './AppointmentForm';

const ClassCalendar : React.FC = () => {
    
    const root = useContext(RootStoreContext);
    const {openModal} = root.modalStore;



    return (
        <FullCalendar defaultView='dayGridMonth' dateClick={(arg) => openModal(<AppointmentForm />)} plugins={[dayGridPlugin, interactionPlugin]} weekends={false} 
        events={[{ title: 'event 1', date: '2020-04-24T16:00:00' }, { title: 'event 2', date: '2020-04-24T18:00:00' }]} />
    )
}

export default observer(ClassCalendar)
