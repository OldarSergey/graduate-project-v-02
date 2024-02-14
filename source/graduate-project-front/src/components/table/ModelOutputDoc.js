function ModelOutputDoc({ documents }) {
    return (
        <div className="centered-content">
                <table className="doc-table"> 
                    <thead>
                        <tr>
                            <th>Внутренний рег. №</th>
                            <th>Дата</th>
                            <th>Создатель</th>
                            <th>Комментарий</th>
                            <th>Вид документа</th>
                            <th>Личный комментарий</th>
                        </tr>
                    </thead>
                    <tbody>
                        {documents.map((document, index) => (
                            <tr key={index}>
                                <td>{document.registrationNumber}</td>
                                <td>{document.date}</td>
                                <td>{document.created}</td>
                                <td>{document.publicComment}</td>
                                <td>{document.typeDoc}</td>
                                <td>{document.privateComment}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
        </div>
    );
}
export default ModelOutputDoc