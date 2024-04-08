import axios from "axios";
import React, { useState, useEffect, useRef } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { BiSearch } from 'react-icons/bi';
import ModelTable from '../components/table/ModelTable';
import { Dropdown } from 'react-bootstrap';
import { NavLink } from 'react-router-dom';
import GetListInstancesDoc from '../components/GetInstance/GetListInstancesDoc';

function OutgoingDocWork() {
    const [documents, setDocuments] = useState([]);
    const [loading, setLoading] = useState(false);
    const [hasMore, setHasMore] = useState(true);
    const [pageNumber, setPageNumber] = useState(1);
    const [documentId, setDocumentId] = useState();
    const [searchDocument, setSearchDocument] = useState("");
    const [selectedItem, setSelectedItem] = useState('Фильтр'); 
    const [nameProcedure, setNameProcedure] = useState("Doc_OutgoingDocumentsWork")

    const pageSize = 25;

    const containerRef = useRef(null);

    const handleDocumentClick = (id) => {
        setDocumentId(id);
    };

    const handleSelect = (eventKey) => {
        setSelectedItem(eventKey); 
    };

    const onChangeNameProcedureOnWork = () => {
        setNameProcedure('Doc_OutgoingDocumentsWork');
    }

    const onChangeNameProcedureOnSpent = () => {
        setNameProcedure('Doc_IncomingSpent');
    }


    const filteredDocuments = documents.filter(document => {
        return document.created.toLowerCase().includes(searchDocument.toLowerCase())
    })
    
    useEffect(() => {
        const fetchData = async () => {
            setLoading(true);
            try {
                const response = await axios.get(`http://176.106.132.3:9982/api/Document/${nameProcedure}/${pageNumber}/${pageSize}`);
                if (response.data.length === 0)  {
                    setHasMore(false); 
                } else {
                    // Проверяем, изменилось ли значение nameProcedure
                    if (nameProcedure !== setNameProcedure.current) {
                        // Если значение nameProcedure изменилось, начинаем заново загружать данные
                        setDocuments(response.data);
                    } else {
                        // Если значение nameProcedure не изменилось, добавляем новые данные к текущему списку
                        setDocuments(prevDocuments => [...prevDocuments, ...response.data]);
                    }
                    // Обновляем текущее значение nameProcedure
                    setNameProcedure.current = nameProcedure;
                }
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
            setLoading(false);
        };
    
        fetchData();
    }, [nameProcedure, pageNumber, pageSize]);

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
                    <button  className="btnCustom" activeClassName="active-button" onClick={()=>onChangeNameProcedureOnWork()} style={{padding:'10px'}}>В работе  </button>
                    <button className="btnCustom" activeClassName="active-button" onClick={()=>onChangeNameProcedureOnSpent()} style={{padding:'10px'}}>Отработанные \\</button>
                    <Dropdown onSelect={handleSelect} className='visiable-dropdown'>
                        <Dropdown.Toggle variant="primary" id="dropdown-basic">
                            {selectedItem}
                        </Dropdown.Toggle>

                        <Dropdown.Menu>
                            <NavLink to="/IncomingDocWork" className="dropdown-item" activeClassName="active" onClick={()=>onChangeNameProcedureOnWork()}>
                                В работе
                            </NavLink>
                            <NavLink to="/IncomingDocSpent" className="dropdown-item" activeClassName="active"  onClick={()=>onChangeNameProcedureOnSpent()}>
                                Отработанные
                            </NavLink>
                        </Dropdown.Menu>
                    </Dropdown>
                </Col>
            </Row>
            <Row className='w-100' >
                <Col className="d-flex flex-column w-100 h-100">
                        <Col >
                            <ModelTable ref={containerRef} documents={filteredDocuments}  onDocumentClick={handleDocumentClick}></ModelTable>
                        </Col>
                </Col>
            </Row>
            <Row className='w-100'>
                <Col>
                     <GetListInstancesDoc documentId={documentId}></GetListInstancesDoc>
                </Col>
            </Row>
        </Container>
    )
}
export default OutgoingDocWork;