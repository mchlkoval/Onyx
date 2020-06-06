import React, { useContext } from 'react'
import { RootStoreContext } from '../../../Stores/RootStore';
import { Segment, Header, Button } from 'semantic-ui-react';

interface IProps {
    id: string,
    name: string
}

const ArchiveCoachModal : React.FC<IProps> = ({id, name}) => {

    const rootStore = useContext(RootStoreContext);
    const {archiveCoach} = rootStore.coachStore;
    const {closeModal} = rootStore.modalStore;

    return (
        <Segment clearing>
            <Header as="h3">Are you sure you want to deactive {name}</Header>
            <Button floated="left" content="Cancel" negative onClick={() => closeModal()}/>
            <Button floated="right" content="Yes" positive onClick={() => 
                archiveCoach(id)
                .finally(() => 
                    closeModal()
                )
            }/> 
        </Segment>
    )
}

export default ArchiveCoachModal
