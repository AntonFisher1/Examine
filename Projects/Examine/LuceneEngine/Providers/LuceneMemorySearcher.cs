using System.Diagnostics;
using System.IO;
using System.Security;
using Lucene.Net.Analysis;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Directory = Lucene.Net.Store.Directory;

namespace Examine.LuceneEngine.Providers
{
    /// <summary>
    /// A Lucene searcher that uses RAMDirectory
    /// </summary>
    public class LuceneMemorySearcher : LuceneSearcher
    {
        private readonly Directory _luceneDirectory;

        /// <summary>
        /// Default constructor
        /// </summary>
        public LuceneMemorySearcher()
        {
        }

        /// <summary>
        /// Constructor to allow for creating an indexer at runtime
        /// </summary>
        /// <param name="luceneDirectory"></param>
        /// <param name="analyzer"></param>
		
        public LuceneMemorySearcher(Directory luceneDirectory, Analyzer analyzer)
        {
            _luceneDirectory = new RAMDirectory(luceneDirectory);;
            IndexingAnalyzer = analyzer;
        }

		
        protected override Directory GetLuceneDirectory()
        {
            return _luceneDirectory;
        }
              
            //Debug.WriteLine("LuceneMemorySearcher.GetSearcher");
            //Debug.WriteLine("LuceneMemorySearcher.GetSearcher");
    }
}