import axios from "axios";
import React, { useState, useEffect, useRef } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import { BiSearch } from 'react-icons/bi';
import "./OutputArchive.css"
import CustomSelect from "./componentArchive/CustomSelect";
import ArchiveList from "./componentArchive/ArchiveList";
import DocumentArchive from "./componentArchive/DocumentArchive";
import ModalWinwowGetArchive from "../components/ModalWindow/ModalWinwowGetArchive";

function OutputArchive(){
    const [archive, setArchive] = useState([]);
    const [keyNote, setKeyNote] = useState(15);
    const [selectedYear, setSelectedYear] = useState(new Date().getFullYear());
    const [searchDocument, setSearchDocument] = useState("");
    const [isModalOpen, setIsModalOpen] = useState(false); // Состояние для открытия и закрытия модального окна

    const handleArchiveClick = (keyNote) => {
        setKeyNote(keyNote);
    };

    const handleYearChange = (yearValue) => {
        setSelectedYear(yearValue);
      };
  
      const handleOpenModal = () => {
        setIsModalOpen(true);
    };

    // Обработчик для закрытия модального окна
    const handleCloseModal = () => {
        setIsModalOpen(false);
    };

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await axios.get(`http://localhost:5254/api/Document/archive/${selectedYear}`);
                setArchive(response.data);
            } catch (error) {
                console.error('Error fetching documents:', error);
            }
        };

        fetchData();
    }, [selectedYear]);

    return (
        <Container fluid className='p-0'style={{ overflowY: 'auto', maxHeight: '100vh' }}> {/* Добавляем стили для прокрутки */}
        <Row className='row-1 m-0 w-100'>
            <Col className="col-auto search-container" >
                <BiSearch className="search-icon" />
                <input 
                className='inputSearch' 
                placeholder="Поиск..."
                onChange={(event) => setSearchDocument(event.target.value)}></input>
            </Col>
            <Col className="col-auto search-container" >
                <button className="btn-custom-archive" onClick={handleOpenModal}>Архив</button> {/* Вызываем модальное окно по клику */}
                <ModalWinwowGetArchive isOpen={isModalOpen} onClose={handleCloseModal} listArchive={archive} onArchiveClick={handleArchiveClick}  ></ModalWinwowGetArchive>
            </Col>

        </Row>
        <Row className='w-100' style={{height:'85vh'}}>
                <Col className="d-none-custom d-flex flex-column archive-col h-100">
                    <Row className="row-archive-one">
                        <CustomSelect selectedYear={selectedYear} handleYearChange={handleYearChange} />
                    </Row>
                    <Row className="row-archive-two" style={{minHeight:"45px"}}>
                        <p className="text-archive">Архив</p>
                    </Row>
                    <Row className="row-archive-three overflow-auto"> {/* Добавляем класс overflow-auto */}
                        <ArchiveList listArchive={archive} onArchiveClick={handleArchiveClick} />
                    </Row>
                    
                </Col>
                <Col className="w-100">
                    <Row>
                        <DocumentArchive keyNote={keyNote} year={selectedYear} search={searchDocument} />
                    </Row>
                </Col>
        </Row>
        
    </Container>
    );
}


export default OutputArchive;