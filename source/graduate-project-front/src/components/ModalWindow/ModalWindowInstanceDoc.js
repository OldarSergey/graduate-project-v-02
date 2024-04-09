import React from "react";
import { Modal } from "react-bootstrap";
import GetListInstancesDoc from "../GetInstance/GetListInstancesDoc";

function ModalWindowInstanceDoc({ isOpen, onClose, documentId }) {
  return (
    <Modal 
      show={isOpen} 
      className="mt-5" 
      onHide={onClose} 
      dialogClassName="modal-90w" 
      style={{ 
        height: '75vh', 
        overflow: 'hidden', 
        width: "100%", 
        overflowX: 'hidden',
        '--bs-modal-zindex': 1055, // Пример применения пользовательских стилей к модальному окну
        '--bs-modal-width': '900px', // Пример применения пользовательских стилей к модальному окну
      }}
    >
      <Modal.Header closeButton>
        <Modal.Title>Маршрут документа</Modal.Title>
      </Modal.Header>

      <Modal.Body style={{ overflowY: "unset", marginLeft: '-25px' }}>
        <GetListInstancesDoc documentId={documentId} />
      </Modal.Body>
    </Modal>
  );
}

export default ModalWindowInstanceDoc;
