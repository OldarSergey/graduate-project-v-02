import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import { Container, Row, Col } from 'react-bootstrap';
import { BiSearch } from 'react-icons/bi';
import { NavLink } from 'react-router-dom';
import ModelTable from '../components/table/ModelTable';
import { Dropdown } from 'react-bootstrap';
import GetListInstancesDoc from '../components/GetInstance/GetListInstancesDoc';
import ModalWindowInstanceDoc from '../components/ModalWindow/ModalWindowInstanceDoc';

function IncomingDocSpent() {
    const [documents, setDocuments] = useState([]);
    const [loading, setLoading] = useState(false);
    const [hasMore, setHasMore] = useState(true);
    const [pageNumber, setPageNumber] = useState(1);
    const [documentId, setDocumentId] = useState();
    const [searchDocument, setSearchDocument] = useState("");
    const [selectedItem, setSelectedItem] = useState('Фильтр'); 
    const [isOpenModal, setIsOpenModal] = useState(false); // Состояние открытости модального окна

    const pageSize = 25;

    const containerRef = useRef(null);

    const handleDocumentClick = (id) => {
        setDocumentId(id);
        if (window.innerWidth <= 1100 && window.innerHeight < window.innerWidth) {
            setIsOpenModal(true); // Открыть модальное окно при клике на документ
        }
    };


    const closeModal = () => {
        setIsOpenModal(false); 
        setDocumentId(null); 
    };

    const handleSelect = (eventKey) => {
        setSelectedItem(eventKey); 
    };


    const filteredDocuments = documents.filter(document => {
        return document.created.toLowerCase().includes(searchDocument.toLowerCase())
    })
    
    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/Document/Doc_IncomingSpent/${pageNumber}/${pageSize}`);
                if (response.data.length === 0) {
                    setHasMore(false); // Все данные загружены
                } else {
                    setDocuments(prevDocuments => [...prevDocuments, ...response.data]);
                }
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
            setLoading(false);
        };

        fetchData();
    }, [pageNumber, pageSize]);

    useEffect(() => {
        const container = containerRef.current;
        if (!container) return;
    
        const handleScroll = () => {
            const { scrollTop, clientHeight, scrollHeight } = container;
            if (scrollTop + clientHeight >= scrollHeight - 80 && !loading && hasMore) {
                setPageNumber(pageNumber => pageNumber + 1);
            }
        };
    
        container.addEventListener('scroll', handleScroll);
        return () => container.removeEventListener('scroll', handleScroll);
    }, [loading, hasMore]); 
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
                    <NavLink to="/IncomingDocWork" className='nav-button btnCustom' >
                        В работе
                    </NavLink>
                    <NavLink to="/IncomingDocSpent" className='nav-button btnCustom ' >
                        Отработанные
                    </NavLink>
                    <Dropdown onSelect={handleSelect} className='visiable-dropdown'>
                        <Dropdown.Toggle variant="primary" id="dropdown-basic">
                            {selectedItem}
                        </Dropdown.Toggle>

                        <Dropdown.Menu>
                            <NavLink to="/IncomingDocWork" className="dropdown-item" activeClassName="active" onClick={() => setSelectedItem("В работе")}>
                                В работе
                            </NavLink>
                            <NavLink to="/IncomingDocSpent" className="dropdown-item" activeClassName="active" onClick={() => setSelectedItem("Отработанные")}>
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
export default IncomingDocSpent;