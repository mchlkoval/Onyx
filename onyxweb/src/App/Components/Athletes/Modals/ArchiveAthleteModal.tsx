import React, { useContext } from 'react'
import { RootStoreContext } from '../../../Stores/RootStore'
import { Segment, Header, Button } from 'semantic-ui-react';

interface IProps {
    id: string,
    name: string
}

const ArchiveAthleteModal : React.FC<IProps> = ({id, name}) => {

    const rootStore = useContext(RootStoreContext);
    const {archiveAthlete} = rootStore.athleteStore;
    const {closeModal} = rootStore.modalStore;

    return (
        <Segment clearing>
            <Header as="h3">Are you sure you want to deactive {name}</Header>
            <Button floated="left" content="Cancel" negative onClick={() => closeModal()}/>
            <Button floated="right" content="Yes" positive onClick={() => 
                archiveAthlete(id)
                .finally(() => 
                    closeModal()
                )
            }/> 
        </Segment>
    )
}

export default ArchiveAthleteModal
