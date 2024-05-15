import { Container, Row, Col } from 'react-bootstrap';
import "./IncomingDocWork.css"
import { BiSearch } from 'react-icons/bi';
import ModelTable from '../../components/Documents/table/ModelTable';
import { Dropdown } from 'react-bootstrap';
import React, { useState, useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import axios from 'axios';
import GetListInstancesDoc from '../../components/Documents/GetInstance/GetListInstancesDoc';
import ModalWindowInstanceDoc from '../../components/Documents/GetInstance/ModalWindow/ModalWindowInstanceDoc';
function IncomingDocWork() {
    const [isOpenModal, setIsOpenModal] = useState(false); // Состояние открытости модального окна
    const [selectedItem, setSelectedItem] = useState('Фильтр'); 
    const [documents, setDocuments] = useState([]);
    const [documentId, setDocumentId] = useState();
    const [searchDocument, setSearchDocument] = useState("");

    const handleDocumentClick = (id) => {
        setDocumentId(id);
        if (window.innerWidth <= 1100 && window.innerHeight < window.innerWidth) {
            setIsOpenModal(true); // Открыть модальное окно при клике на документ
        }
    };
    
    
    const handleSelect = (eventKey) => {
        setSelectedItem(eventKey); 
    };

    const closeModal = () => {
        setIsOpenModal(false); 
        setDocumentId(null); 
    };
    

    const filteredDocuments = documents.filter(document => {
        return document.created.toLowerCase().includes(searchDocument.toLowerCase())
    })

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/Document?resultModel=1`);
                setDocuments(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }           
        };
        fetchData();
    }, []); 

    
    return (
        <Container fluid className='p-0' style={{ overflowY: 'auto', maxHeight: '100vh' }}> {/* Добавляем стили для прокрутки */}
            <Row className='row-1 m-0 w-100'>
                <Col className="col-auto search-container ">
                    <BiSearch className="search-icon" />
                    <input 
                    className='inputSearch' 
                    placeholder="Поиск..."
                    onChange={(event) => setSearchDocument(event.target.value)}></input>
                </Col>

                <Col className="d-flex align-items-start">
                    <NavLink to="/IncomingDocWork" className='nav-button btnCustom' activeClassName="active-button">
                        В работе
                    </NavLink>
                    <NavLink to="/IncomingDocSpent" className='nav-button btnCustom' activeClassName="active-button">
                        Отработанные
                    </NavLink>
                    <Dropdown onSelect={handleSelect} className='visiable-dropdown'>
                        <Dropdown.Toggle variant="primary" id="dropdown-basic">
                            {selectedItem}
                        </Dropdown.Toggle>

                        <Dropdown.Menu>
                            <NavLink to="/IncomingDocWork" className="dropdown-item" activeClassName="active"  onClick={() => setSelectedItem("В работе")}>
                                В работе
                            </NavLink>
                            <NavLink to="/IncomingDocSpent" className="dropdown-item"  activeClassName="active" onClick={() => setSelectedItem("Отработанные")}>
                                Отработанные
                            </NavLink>
                        </Dropdown.Menu>
                    </Dropdown>
                </Col>
            </Row>
            <Row className='w-100' >
                <Col className="d-flex flex-column w-100 h-100">
                        <Col>
                            <ModelTable documents={filteredDocuments}  onDocumentClick={handleDocumentClick}></ModelTable>
                            <ModalWindowInstanceDoc isOpen={isOpenModal} onClose={closeModal} documentId={documentId}></ModalWindowInstanceDoc>
                        </Col>
                </Col>
            </Row>
            <Row className='w-100 inst-visiable'>
                <Col className='inst-visiable'>
                     <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                </Col>
            </Row>
        </Container>
    )
}
export default IncomingDocWork;