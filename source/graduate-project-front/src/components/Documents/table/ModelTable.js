import React, { useState } from 'react';
import "./ModelTable.css"

import { Col, Row } from 'react-bootstrap';
import { format } from 'date-fns';
import ModalWindowProperty from '../CardMenuDocument/ModalWindow/ModalWindowProperty';
import ContextMenu from '../CardMenuDocument/ContextMenu';
import ModalWindowRouteDocementGraf from '../CardMenuDocument/ModalWindow/ModalWindowRouteDocementGraf';
import ModalWindowInstanceDoc from '../GetInstance/ModalWindow/ModalWindowInstanceDoc';

const ModelTable = React.forwardRef(({ documents, onDocumentClick }, ref) => {

    const [openContextMenuId, setOpenContextMenuId] = useState(null);
    const [openModaRoute, setOpenModalRoute] = useState(null);
    const [openModaProperty, setOpenModalProperty] = useState(null);
    const [openModaRouteGraf, setOpenModaRouteGraf] = useState(null);
    const [contextMenuPos, setContextMenuPos] = useState({ x: 0, y: 0 });

     const openModal = (func, documentId) => func(documentId);

     const closeModal = (func) => func(null);

    const handleContextMenu = (event, documentId) => {
      event.preventDefault();
      setContextMenuPos({ x: event.pageX, y: event.pageY });
      setOpenContextMenuId(documentId);
    };

    const handleProperty = (documentId) => {
      // Открыть модальное окно свойств
      setOpenModalProperty(documentId);
    };

    const handleAttachment = () => {
        // Обработка действия "Вложения"

      };
      const handleRoute = (documentId)  => {
       // Открыть модальное окно "Маршрут"
       setOpenModaRouteGraf(documentId);
      };
      const handlePermission = () => {
        // Обработка действия "Разрешения"

      };
    const handleEvent = () => {
      // Обработка действия "События"

    };

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
                        <col style={{ width: '5%' }} /> {/* Ширина седьмого столбца */}
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
                        {documents.map(document => (
                            <tr key={document.id} onClick={() => onDocumentClick(document.id)} onContextMenu={(e) => handleContextMenu(e, document.id)}>
                               <td data-label='№'>{document.registrationNumber}</td>
                                <td data-label='Дата'>{format(new Date(document.date), 'dd.MM.yyyy')}</td>
                                <td data-label='Создатель'>{document.created}</td>
                                <td data-label=''>{document.publicComment}</td>
                                <td data-label=''>{document.typeDoc}</td>
                                <td className='personal-comment' data-label='Личный комментарий'>{document.privateComment}</td>
                                <td style={{zIndex:"unset"}}>
                                    <button className='btn-custom ml-3' style={{ margin: '0', marginRight: '10px' }}>Свойства</button>
                                    <button className='btn-custom ml-4' onClick={() => openModal(setOpenModalRoute, document.id)} style={{ margin: '0' }}>Маршрут</button>
                                    <button className='button-reset' style={{ cursor: 'pointer', width: '100%' }}></button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                {openContextMenuId !== null && (
                <ContextMenu
                    posX={contextMenuPos.x}
                    posY={contextMenuPos.y}
                    onClose={() => setOpenContextMenuId(null)}
                    onProperty={handleProperty}
                    onAtaa={handleAttachment}
                    onAttachment={handleAttachment}
                    onRoute={handleRoute}
                    onPermission={handlePermission}
                    onEvent={handleEvent}
                    registrationNumber={documents.find(doc => doc.id === openContextMenuId).registrationNumber}
                />
                )}

                {openModaProperty !== null && (
                  <ModalWindowProperty isOpen={true} onClose={() => closeModal(setOpenModalProperty)} documentId={openModaProperty}></ModalWindowProperty>
                )}
                 {openModaRouteGraf !== null && (
                  <ModalWindowRouteDocementGraf isOpen={true} onClose={() => closeModal(setOpenModaRouteGraf)} documentId={openContextMenuId}></ModalWindowRouteDocementGraf>
                )}   
                {openModaRoute !== null && (
                  <ModalWindowInstanceDoc isOpen={true} onClose={() => closeModal(setOpenModalRoute)} documentId={openModaRoute}></ModalWindowInstanceDoc>
                )}
            </div>
        </div>
    );
});

export default ModelTable;

