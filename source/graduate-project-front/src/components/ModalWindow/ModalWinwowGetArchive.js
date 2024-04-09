import React from 'react';
import { Modal } from 'react-bootstrap';
import ArchiveList from '../../pages/componentArchive/ArchiveList';
function ModalWinwowGetArchive({ isOpen, onClose, listArchive, onArchiveClick }) {
    return (
      <Modal show={isOpen} className="mt-5" onHide={onClose} dialogClassName="modal-90w" style={{ height: '75vh', overflow: 'hidden', width: '100%', overflowX: 'hidden' }}>
        <Modal.Header closeButton>
          <Modal.Title>Выбор архива</Modal.Title>
        </Modal.Header>
        <Modal.Body style={{ overflowY: 'auto' }}>
           <ArchiveList listArchive={listArchive} onArchiveClick={onArchiveClick} />
        </Modal.Body>
      </Modal>
    );
  }
  
  export default ModalWinwowGetArchive;
  

