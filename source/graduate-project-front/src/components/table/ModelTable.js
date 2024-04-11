import React, { useState } from 'react';
import "./ModelTable.css"
import { Col, Row } from 'react-bootstrap';
import ModalWindowInstanceDoc from '../ModalWindow/ModalWindowInstanceDoc';
import { format } from 'date-fns';

const ModelTable = React.forwardRef(({ documents, onDocumentClick }, ref) => {

    const [openDocumentId, setOpenDocumentId] = useState(true);

    const openModal = (documentId) => setOpenDocumentId(documentId);
    const closeModal = () => setOpenDocumentId(null);

    return (
        <div className="table-responsive m-3 outer-wrapper" >
            <div className='table-wrapper' ref={ref}>
                <table className="delivery table m-3 model-table-custom box-shadow table-bordered table-hover" style={{ width: '98%' }}>
                    <colgroup>
                        <col style={{ width: '13%' }} /> {/* Ширина первого столбца */}
                        <col style={{ width: '10%' }} /> {/* Ширина второго столбца */}
                        <col style={{ width: '12%' }} /> {/* Ширина третьего столбца */}
                        <col style={{ width: '25%' }} /> {/* Ширина четвертого столбца */}
                        <col style={{ width: '13%' }} /> {/* Ширина пятого столбца */}
                        <col style={{ width: '15%' }} /> {/* Ширина шестого столбца */}
                        <col style={{ width: '5%' }} /> {/* Ширина шестого столбца */}
                    </colgroup>
                    <thead className="rectangle-6">
                        <tr>
                            <th className='th-custom'>Внутренний рег.№</th>
                            <th style={{ width: '10%' }}>Дата</th> {/* Пример регулирования ширины второго столбца */}
                            <th>Создатель</th>
                            <th>Комментарий</th>
                            <th>Вид документа</th>
                            <th className='personal-comment'>Личный комментарий</th>
                            <th></th>
                        </tr>
                    </thead>

                    <tbody>
                        {documents.map((document, index) => (
                            <tr key={index} onClick={() => onDocumentClick(document.id)}>
                                <td data-label='№'>{document.registrationNumber}</td>
                                <td data-label='Дата'>{format(new Date(document.date), 'dd.MM.yyyy')}</td>
                                <td data-label='Создатель'>{document.created}</td>
                                <td data-label=''>{document.publicComment}</td>
                                <td data-label=''>{document.typeDoc}</td>
                                <td className='personal-comment' data-label='Личный комментарий'>{document.privateComment}</td>
                                <td>
                                    <button className='btn-custom ml-3' style={{ margin: '0', marginRight: '10px' }}>Свойства</button>
                                    <button className='btn-custom ml-4' onClick={() => openModal(document.id)} style={{ margin: '0' }}>Маршрут</button>
                                    {openDocumentId === document.id && <ModalWindowInstanceDoc isOpen={true} onClose={closeModal} documentId={document.id}></ModalWindowInstanceDoc>}
                                    <button className='button-reset' style={{ cursor: 'pointer', width: '100%' }}>
                                        <i className="bi bi-sliders2"></i>
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
});

export default ModelTable;
