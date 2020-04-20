import React, { useContext } from 'react'
import { Modal} from 'semantic-ui-react'
import { observer } from 'mobx-react-lite';
import { RootStoreContext } from '../../../Stores/RootStore';

const ModalContainer = () => {

    const root = useContext(RootStoreContext);
    const {modal: {open, body}, closeModal} = root.modalStore;

    return (
    <Modal open={open} onClose={closeModal} size='mini'>
        <Modal.Content >
            {body}
        </Modal.Content>
    </Modal>
    )
}

export default observer(ModalContainer)
