import React from 'react';

function TableInstancesDoc({ instancesDoc }) {
    return (
        <div className="mt-10" style={{ maxHeight: '400px', overflow: 'auto' }}>
            <table className="doc-table">
                <thead>
                    <tr>
                        <th>Указал действие</th>
                        <th>Исполнитель действия</th>
                        <th>Действие с документом</th>
                        <th>Комментарий исполнителя</th>
                        <th>Начал работу</th>
                        <th>Выполнен работа</th>
                        <th>Получено в работу</th>
                    </tr>
                </thead>
                <tbody>
                    {instancesDoc.map((instance, index) => (
                        <tr key={index}>
                            <td>{instance.userSender}</td>
                            <td>{instance.userExecutor}</td>
                            <td>{instance.operation}</td>
                            <td>{instance.commentExecutor}</td>
                            <td>{new Date(instance.started).toLocaleDateString()}</td>
                            <td>{new Date(instance.executed).toLocaleDateString()}</td>
                            <td>{new Date(instance.received).toLocaleDateString()}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default TableInstancesDoc;
