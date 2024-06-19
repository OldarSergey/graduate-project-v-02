import React, { useEffect, useState } from 'react';
import { Modal, Table } from 'react-bootstrap';
import "./ModalWindowProperty.css";

function ModalWindowProperty({ isOpen, onClose, documentId, documents }) {
  const landscapeStyle = window.matchMedia("(max-width: 1100px) and (orientation: landscape)").matches ? { marginTop: '-32px' } : {};
  const [document, setDocument] = useState(null);

  useEffect(() => {
    if (documentId && documents) {
      const foundDocument = documents.find(doc => doc.id === documentId);
      setDocument(foundDocument);
    }
  }, [documentId, documents]);

  return (
    <Modal 
      show={isOpen} 
      className="mt-5" 
      onHide={onClose} 
    >
      <Modal.Header closeButton>
        <Modal.Title>Свойства документа</Modal.Title>
      </Modal.Header>

      <Modal.Body>
        {document ? (
          <div className="table-responsive">
            <Table striped bordered hover>
              <tbody>
                <tr>
                  <td className="first-column">Ключ</td>
                  <td>{documentId}</td>
                </tr>
                <tr>
                  <td className="first-column">Вид</td>
                  <td>{document.typeDoc}</td>
                </tr>
                <tr>
                  <td className="first-column">Номер</td>
                  <td>{document.registrationNumber}</td>
                </tr>
                <tr>
                  <td className="first-column">Дата начала</td>
                  <td>{document.date}</td>
                </tr>
                <tr>
                  <td className="first-column">Создатель</td>
                  <td>{document.created}</td>
                </tr>
                <tr>
                  <td className="first-column">Гриф секретности</td>
                  <td>{document.security}</td>
                </tr>
                <tr>
                  <td className="first-column">Комментарий</td>
                  <td>{document.publicComment}</td>
                </tr>
              </tbody>
            </Table>
          </div>
        ) : (
          <div>Документ не найден</div>
        )}
      </Modal.Body>
    </Modal>
  );
}

export default ModalWindowProperty;
