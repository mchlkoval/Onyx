import React, { useContext } from 'react'
import { RootStoreContext } from '../../../Stores/RootStore';
import { Segment, Header, Button } from 'semantic-ui-react';

interface IProps {
    id: string,
    name: string
}

const ReactivateAthleteModal : React.FC<IProps>= ({id, name}) => {

    const rootStore = useContext(RootStoreContext);
    const {reactiveAthlete} = rootStore.athleteStore;
    const {closeModal} = rootStore.modalStore;

    return (
        <Segment clearing>
            <Header as="h3">Are you sure you want to re-activate {name}</Header>
            <Button floated="left" content="Cancel" negative onClick={() => closeModal()}/>
            <Button floated="right" content="Yes" positive onClick={() => 
                reactiveAthlete(id)
                .finally(() => 
                    closeModal()
                )
            }/> 
        </Segment>
    )
}

export default ReactivateAthleteModal
