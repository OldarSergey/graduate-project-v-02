import './ModalDetailed.css'
import { useState, useEffect } from 'react';
import axios from "axios";
import { Modal, Button } from "react-bootstrap";

const ModalDetailed = ({ active, onClose, employeeId, employee }) => {

    return (
        <Modal show={active} className="mt-5" onHide={onClose} dialogClassName="modal-90w" style={{ height: '75vh', overflow: 'hidden', width: "100%", overflowX: 'hidden' }}>
            <Modal.Header closeButton>
                <Modal.Title>{employee.fullName}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <p>Телефон: {employee.phone}</p>
                <p>Отдел: {employee.department}</p>
                <p>Должность: {employee.duty}</p>
            </Modal.Body>
        </Modal>
    );
}

export default ModalDetailed;
