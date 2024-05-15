import React, { useState, useEffect } from 'react';
import "./ModalWindowRouteDocementGraf.css"

import axios from 'axios';
import { Modal, Form,Row,Col, Table } from 'react-bootstrap';
import TreeDiagram from '../TreeDiagram';
function ModalWindowRouteDocementGraf({ isOpen, onClose, documentId }) {
  const landscapeStyle = window.matchMedia("(max-width: 1100px) and (orientation: landscape)").matches ? { marginTop: '-32px' } : {};
  const [instancesDoc, setInstancesDoc] = useState(null); 
  const [userExecutor, setUserExecutor] = useState('');
  const [userSender, setUserSender] = useState('');
  const [selectedNodeData, setSelectedNodeData] = useState("");
 
  useEffect(() => {
    if (documentId!= undefined || null) {
      fetchData();
    }
  },);

  const fetchData = async () => {
    try {
      const response = await axios.get(`http://176.106.132.3:9982/api/Document/${documentId}`);
      setInstancesDoc(response.data);
    } catch (error) {
      console.error('Error fetching documents:', error);
    }
  };

  const handleNodeClick = (nodeData, userSender) => {
    setSelectedNodeData(nodeData.attributes);
    setUserExecutor(nodeData.name)
    setUserSender(userSender)
  };

  return (
<Modal 
  show={isOpen} 
  className="mt-5" 
  dialogClassName="custom-modal"
  onHide={onClose} 
  onShow={fetchData} // Вызываем fetchData при отображении модального окна
>
  <Modal.Header closeButton>
    <Modal.Title>Маршрут документа</Modal.Title>
  </Modal.Header>

  <Modal.Body>
    <Table striped bordered hover>
      {/* Проверяем instancesDoc перед передачей в компонент TreeDiagram */}
      {instancesDoc && <TreeDiagram data={instancesDoc} onNodeClick={handleNodeClick} />}
    </Table>
  </Modal.Body>
 
        
        
       
        
  <Modal.Footer style={{ justifyContent: 'normal' }}>
  <Form>
    <Row>
      <Col>
        <Row>
          <Form.Group controlId="executor" className="d-flex align-items-center">
            <Form.Label className="mr-2">Исполнитель:</Form.Label>
            <Form.Control style={{ marginLeft: '5px' }} type="text" defaultValue={userExecutor} />
          </Form.Group>
        </Row>
        <Row className='mt-2'>
          <Form.Group controlId="action" className="d-flex align-items-center">
            <Form.Label className="mr-2">Действие:</Form.Label>
            <Form.Control style={{ marginLeft: '5px' }} type="text" defaultValue={selectedNodeData.operation} />
          </Form.Group>
        </Row>
        <Row>
        <Form.Group controlId="specifiedAction" className="d-flex align-items-center">
          <Form.Label className="mr-2">Указано действие:</Form.Label>
          <Form.Control type="text" defaultValue={userSender} />
        </Form.Group>
        </Row>
      </Col>
      {/* Проверяем ширину экрана */}
      {window.innerWidth > 541 ? (
        <Col>
          <Row>
            <Form.Group controlId="startWork" className="d-flex align-items-center">
              <Form.Label className="mr-2">Начал работу:</Form.Label>
              <Form.Control style={{ marginLeft: '5px', width: '50%' }} type="text"
              defaultValue={selectedNodeData && selectedNodeData.started ? new Date(selectedNodeData.started).toISOString().split('T')[0] : ''}/>
            </Form.Group>
          </Row>
          <Row>
          <Row className='mt-2'>
            <Form.Group controlId="actionCompleted" className="d-flex align-items-center">
              <Form.Label className="mr-2">Выполнено:</Form.Label>
              <Form.Control style={{ marginLeft: '5px' }} type="text"  
                defaultValue={selectedNodeData && selectedNodeData.executed ? new Date(selectedNodeData.executed).toISOString().split('T')[0] : ''}/>
            </Form.Group>
          </Row>
          <Row className='mt-2'>
          <Form.Group controlId="startWork" className="d-flex align-items-center">
              <Form.Label className="mr-2">Получено в работу:</Form.Label>
              <Form.Control style={{ marginLeft: '5px', width: '50%' }} type="text"
              defaultValue={selectedNodeData && selectedNodeData.received ? new Date(selectedNodeData.received).toISOString().split('T')[0] : ''}/>
            </Form.Group>
          </Row>
            
          </Row>
       
        </Col>
      ) : <Row>
          <Form.Group controlId="startWork" className="d-flex align-items-center">
            <Form.Label className="mr-2">Начал работу:</Form.Label>
            <Form.Control style={{ marginLeft: '5px', width: '50%' }} type="text" 
              defaultValue={selectedNodeData && selectedNodeData.started ? new Date(selectedNodeData.started).toISOString().split('T')[0] : ''}/>
          </Form.Group>
          <Form.Group controlId="actionCompleted" className="d-flex align-items-center">
              <Form.Label className="mr-2">Выполнено:</Form.Label>
              <Form.Control style={{ marginLeft: '5px' }} type="text" 
                defaultValue={selectedNodeData && selectedNodeData.executed ? new Date(selectedNodeData.executed).toISOString().split('T')[0] : ''}/>
            </Form.Group>
          <Form.Group controlId="startWork" className="d-flex align-items-center">
            <Form.Label className="mr-2">Получено в работу:</Form.Label>
            <Form.Control style={{ marginLeft: '5px', width: '50%' }} type="text" 
              defaultValue={selectedNodeData && selectedNodeData.received ? new Date(selectedNodeData.received).toISOString().split('T')[0] : ''}/>
          </Form.Group>
         
        </Row>
      }
    </Row>
  </Form>
</Modal.Footer>



</Modal>

  );
}

export default ModalWindowRouteDocementGraf;
