import axios from "axios";
import React, { useState, useEffect } from 'react';
import ModelTable from "../../components/table/ModelTable";
import GetListInstancesDoc from "../../components/GetInstance/GetListInstancesDoc";
import { Container, Row, Col } from 'react-bootstrap';
import ModalWindowInstanceDoc from "../../components/ModalWindow/ModalWindowInstanceDoc";

function DocumentArchive({ keyNote, year, search }) {
    const [docArchive, setDocArchive] = useState([]);
    const [archiveId, setArchiveId] = useState();
    const [pageNumber, setPageNumber] = useState(1);
    const [pageSize, setPageSize] = useState(25);
    const [isOpenModal, setIsOpenModal] = useState(false);

    const handleDocumentClick = (id) => {
        setArchiveId(id);
        if (window.innerWidth <= 1100 && window.innerHeight < window.innerWidth) {
            setIsOpenModal(true); // Открыть модальное окно при клике на документ
        }
    };

    const closeModal = () => {
        setIsOpenModal(false); 
        setArchiveId(null); 
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:5254/api/Document/archive/${keyNote}/${keyNote}/${pageNumber}/${pageSize}?userId=23546`);
                setDocArchive(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [keyNote, year, pageNumber, pageSize]);

    const filteredDocuments = docArchive.filter(archive => {
        return archive.created.toLowerCase().includes(search.toLowerCase())
    })

    return (
        <Container fluid className='p-0'>
            <Row className='w-100'>
                <Col className="d-flex flex-column w-100 h-100">
                    <Col>
                        <ModelTable documents={filteredDocuments} onDocumentClick={handleDocumentClick}></ModelTable>
                        <ModalWindowInstanceDoc isOpen={isOpenModal} onClose={closeModal} documentId={archiveId}></ModalWindowInstanceDoc>
                    </Col>
                </Col>
            </Row>
            <Row className='w-100 inst-visiable'>
                <Col className='inst-visiable'>
                    <GetListInstancesDoc documentId={archiveId}></GetListInstancesDoc>
                </Col>
            </Row>
        </Container>
    )
}
export default DocumentArchive;
