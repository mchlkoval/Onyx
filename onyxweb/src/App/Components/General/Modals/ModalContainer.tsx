import React, { useContext } from 'react'
import { observer } from 'mobx-react-lite';
import { RootStoreContext } from '../../../Stores/RootStore';
import Modal from 'react-bootstrap/Modal'

const ModalContainer = () => {

    const root = useContext(RootStoreContext);
    const {modal: {open, body}, closeModal} = root.modalStore;

    return (
    <Modal show={open} onHide={closeModal}>
        <Modal.Body >
            {body}
        </Modal.Body>
    </Modal>
    )
}

export default observer(ModalContainer)
