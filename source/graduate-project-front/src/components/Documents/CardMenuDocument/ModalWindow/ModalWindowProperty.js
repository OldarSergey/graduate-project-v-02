import React from 'react';
import { Modal, Table } from 'react-bootstrap';
import "./ModalWindowProperty.css";

function ModalWindowProperty({ isOpen, onClose }) {
  const landscapeStyle = window.matchMedia("(max-width: 1100px) and (orientation: landscape)").matches ? { marginTop: '-32px' } : {};

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
        <Table striped bordered hover>
          <tbody>
            <tr>
              <td className="first-column">Ключ</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Вид</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Родитель</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Номер</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Дата начала</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Зарегистрирован</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Дата окончания</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Создатель</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Гриф секретности</td>
              <td>dddd</td>
            </tr>
            <tr>
              <td className="first-column">Комментарий</td>
              <td>dddd</td>
            </tr>
          </tbody>
        </Table>
      </Modal.Body>
    </Modal>
  );
}

export default ModalWindowProperty;
